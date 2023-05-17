namespace Tests;

using Microsoft.Extensions.Options;
using TeslaAPI;
using TeslaAPI.Models.Response;
using TeslaAPI.Models.Vehicles;
using Tests.Models;
using Xunit;

public class VehicleStateTests : BaseTests
{
    public VehicleStateTests(IOptions<TeslaConfiguration> teslaConfiguration, ITeslaAPI teslaAPI)
        : base(teslaConfiguration, teslaAPI)
    {
    }

    [Fact]
    public async Task TestGetVehicleDataAsync()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            Vehicle vehicle = await API.GetVehicleDataAsync(Client, Configuration.VehicleID);
        });
        Assert.Null(exception);
    }

    [Fact]
    public async Task TestGetMobileEnabledAsync()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            bool mobileEnabled = await API.GetMobileEnabledAsync(Client, Configuration.VehicleID);
        });
        Assert.Null(exception);
    }

    [Fact]
    public async Task TestGetNearbyChargingSitesAsync()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            NearbyChargingSitesResponse nearbyChargingSites = await API.GetNearbyChargingSitesAsync(Client, Configuration.VehicleID);
        });
        Assert.Null(exception);
    }
}
