namespace Tests;

using Microsoft.Extensions.Options;
using TeslaAPI;
using TeslaAPI.Models.Vehicles;
using Tests.Models;
using Xunit;

public class VehicleTests : BaseTests
{
    public VehicleTests(IOptions<TeslaConfiguration> teslaConfiguration, ITeslaAPI teslaAPI)
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
            NearbyChargingSites nearbyChargingSites = await API.GetNearbyChargingSitesAsync(Client, Configuration.VehicleID);
        });
        Assert.Null(exception);
    }

    [Fact]
    public async Task TestGetReleaseNotesAsync()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            ReleaseNotesResponse releaseNotes = await API.GetReleaseNotesAsync(Client, Configuration.VehicleID);
        });
        Assert.Null(exception);
    }
}
