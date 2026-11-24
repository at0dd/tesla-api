namespace Tests.Unit;

using System.Globalization;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using TeslaAPI;
using TeslaAPI.Exceptions;
using TeslaAPI.Models.Response;
using TeslaAPI.Models.Users;
using TeslaAPI.Models.Vehicles;
using Tests.Support;

/// <summary>
/// Checks how responses, errors and helper methods are handled, against a stub handler instead of the Tesla API.
/// </summary>
public class ResponseHandlingTests
{
    private readonly TeslaAPI api = new();

    [Test]
    public async Task UnwrapsSingleObjectResponse()
    {
        (HttpClient client, _) = StubHttpMessageHandler.CreateClient("""{"response":{"email":"owner@example.com","full_name":"Owner"}}""");

        User user = await api.GetMeAsync(client);

        await Assert.That(user.Email).IsEqualTo("owner@example.com");
        await Assert.That(user.FullName).IsEqualTo("Owner");
    }

    [Test]
    public async Task UnwrapsListResponse()
    {
        (HttpClient client, _) = StubHttpMessageHandler.CreateClient("""{"response":[{"id":1,"vin":"VIN1"},{"id":2,"vin":"VIN2"}],"count":2}""");

        List<Vehicle> vehicles = await api.GetAllVehiclesAsync(client);

        await Assert.That(vehicles.Select(v => v.VIN)).IsEquivalentTo(["VIN1", "VIN2"]);
    }

    [Test]
    public async Task GetAllVehiclesLeavesOutEnergySites()
    {
        (HttpClient client, _) = StubHttpMessageHandler.CreateClient("""{"response":[{"id":1,"vin":"VIN1"},{"energy_site_id":2,"resource_type":"battery"}],"count":2}""");

        List<Vehicle> vehicles = await api.GetAllVehiclesAsync(client);

        await Assert.That(vehicles.Select(v => v.VIN)).IsEquivalentTo(["VIN1"]);
    }

    [Test]
    public async Task ReturnsCommandResponseWithoutUnwrapping()
    {
        (HttpClient client, _) = StubHttpMessageHandler.CreateClient("""{"reason":"already_set","result":false}""");

        CommandResponse response = await api.HonkHornAsync(client, "123");

        await Assert.That(response.Result).IsFalse();
        await Assert.That(response.Reason).IsEqualTo("already_set");
    }

    [Test]
    public async Task ThrowsWithStatusCodeAndMessageOnUnsuccessfulResponse()
    {
        (HttpClient client, _) = StubHttpMessageHandler.CreateClient("""{"error":"vehicle unavailable"}""", HttpStatusCode.RequestTimeout);

        TeslaApiRequestUnsuccessfulException? exception = await Assert.That(() => api.GetVehicleAsync(client, "123"))
            .ThrowsExactly<TeslaApiRequestUnsuccessfulException>();

        await Assert.That(exception!.ResponseCode).IsEqualTo(HttpStatusCode.RequestTimeout);
        await Assert.That(exception.Message).IsEqualTo("vehicle unavailable");
    }

    [Test]
    public async Task AttachesResponseBodyWhenDeserializationFails()
    {
        (HttpClient client, _) = StubHttpMessageHandler.CreateClient("""{"response":"not a bool"}""");

        Exception? exception = await Assert.That(() => api.GetMobileEnabledAsync(client, "123")).Throws<Exception>();

        await Assert.That(exception!.Data["TeslaAPI.Response"]).IsEqualTo("""{"response":"not a bool"}""");
    }

    [Test]
    public async Task GetAccessTokenSendsBearerToken()
    {
        (HttpClient client, StubHttpMessageHandler handler) = StubHttpMessageHandler.CreateClient("{}");

#pragma warning disable CS0618
        await api.GetAccessTokenAsync(client, "id", "secret", "bearer");
#pragma warning restore CS0618

        await Assert.That(handler.LastRequest.Headers["Authorization"]).IsEqualTo("Bearer bearer");
    }

    [Test]
    public async Task ShareWithoutTimestampUsesCurrentTime()
    {
        (HttpClient client, StubHttpMessageHandler handler) = StubHttpMessageHandler.CreateClient("{}");
        long before = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        await api.ShareAsync(client, "123", "1 Tesla Rd");

        long timestamp = long.Parse(JToken.Parse(handler.LastRequest.Body!)["timestamp_ms"]!.Value<string>()!, CultureInfo.InvariantCulture);
        await Assert.That(timestamp).IsGreaterThanOrEqualTo(before);
        await Assert.That(timestamp).IsLessThanOrEqualTo(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
    }

    [Test]
    public async Task ShareCoordinatesExtensionFormatsLatitudeAndLongitude()
    {
        (HttpClient client, StubHttpMessageHandler handler) = StubHttpMessageHandler.CreateClient("{}");

        await api.ShareAsync(client, "123", 40.5f, -74.25f);

        JToken body = JToken.Parse(handler.LastRequest.Body!);
        await Assert.That(body["value"]!["android.intent.extra.TEXT"]!.Value<string>()).IsEqualTo("40.5,-74.25");
        await Assert.That(body["locale"]!.Value<string>()).IsEqualTo("en-US");
    }

    [Test]
    public async Task DecimalValuesIgnoreCurrentCulture()
    {
        (HttpClient client, StubHttpMessageHandler handler) = StubHttpMessageHandler.CreateClient("{}");
        CultureInfo original = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = new CultureInfo("de-DE");

        try
        {
            await api.ClimateSetTemperaturesAsync(client, "123", 21.5, 22.5);
            await api.TriggerHomelinkAsync(client, "123", 40.5, -74.25);
        }
        finally
        {
            CultureInfo.CurrentCulture = original;
        }

        await Assert.That(handler.Requests[0].Body).IsEqualTo("""{"driver_temp":21.5,"passenger_temp":22.5}""");
        await Assert.That(handler.Requests[1].Body).IsEqualTo("""{"lat":40.5,"lon":-74.25}""");
    }

    [Test]
    public async Task AddTeslaApiRegistersScopedService()
    {
        ServiceCollection services = new();

        services.AddTeslaApi();

        ServiceDescriptor descriptor = services.Single(s => s.ServiceType == typeof(ITeslaAPI));
        await Assert.That(descriptor.ImplementationType).IsEqualTo(typeof(TeslaAPI));
        await Assert.That(descriptor.Lifetime).IsEqualTo(ServiceLifetime.Scoped);
    }
}
