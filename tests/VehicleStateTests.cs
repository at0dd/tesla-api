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
            Vehicle vehicle = await API.GetVehicleDataAsync(Client, VehicleID);
        });
        Assert.Null(exception);
    }

    [Fact]
    public async Task TestGetVehicleChargeStateAsync()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            ChargeState chargeState = await API.GetVehicleChargeStateAsync(Client, VehicleID);
        });
        Assert.Null(exception);
    }

    [Fact]
    public async Task TestGetVehicleClimateStateAsync()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            ClimateState climateState = await API.GetVehicleClimateStateAsync(Client, VehicleID);
        });
        Assert.Null(exception);
    }

    [Fact]
    public async Task TestGetVehicleDriveStateAsync()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            DriveState driveState = await API.GetVehicleDriveStateAsync(Client, VehicleID);
        });
        Assert.Null(exception);
    }

    [Fact]
    public async Task TestGetVehicleGUISettingsAsync()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            GUISettings guiSettings = await API.GetVehicleGUISettingsAsync(Client, VehicleID);
        });
        Assert.Null(exception);
    }

    [Fact]
    public async Task TestGetVehicleStateAsync()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            VehicleState vehicleState = await API.GetVehicleStateAsync(Client, VehicleID);
        });
        Assert.Null(exception);
    }

    [Fact]
    public async Task TestGetVehicleConfigAsync()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            VehicleConfig vehicleConfig = await API.GetVehicleConfigAsync(Client, VehicleID);
        });
        Assert.Null(exception);
    }

    [Fact]
    public async Task TestGetMobileEnabledAsync()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            bool mobileEnabled = await API.GetMobileEnabledAsync(Client, VehicleID);
        });
        Assert.Null(exception);
    }

    [Fact]
    public async Task TestGetNearbyChargingSitesAsync()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            NearbyChargingSitesResponse nearbyChargingSites = await API.GetNearbyChargingSitesAsync(Client, VehicleID);
        });
        Assert.Null(exception);
    }
}
