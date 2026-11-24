namespace Tests;

using TeslaAPI;
using TeslaAPI.Models.Response;
using Tests.Support;

/// <summary>
/// Parses responses recorded from the Tesla API, served through a stub handler instead of the Tesla API.
/// </summary>
public class DeserializerTests
{
    [Test]
    public async Task ParsesRecordedVehicleData()
    {
        string json = await File.ReadAllTextAsync(Path.Combine(AppContext.BaseDirectory, "responses/vehicle_data/20240923.json"));
        (HttpClient client, _) = StubHttpMessageHandler.CreateClient(json);

        VehicleData data = await new TeslaAPI().GetVehicleDataAsync(client, "1111111111");

        await Assert.That(data.ID).IsEqualTo(1111111111);
        await Assert.That(data.State).IsEqualTo("online");
        await Assert.That(data.ChargeState.BatteryLevel).IsEqualTo(39);
        await Assert.That(data.VehicleState.CarVersion).IsEqualTo("2024.32.3 2e59c0a47060");
    }
}
