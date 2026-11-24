namespace Tests;

using TeslaAPI.Models.Vehicles;

public class VehicleTests : BaseTests
{
    [Test]
    public async Task TestGetVehicleDataAsync()
    {
        _ = await API.GetVehicleDataAsync(Client, Configuration.VehicleID);
    }

    [Test]
    public async Task TestGetMobileEnabledAsync()
    {
        _ = await API.GetMobileEnabledAsync(Client, Configuration.VehicleID);
    }

    [Test]
    public async Task TestGetNearbyChargingSitesAsync()
    {
        _ = await API.GetNearbyChargingSitesAsync(Client, Configuration.VehicleID);
    }

    [Test]
    public async Task TestGetReleaseNotesAsync()
    {
        _ = await API.GetReleaseNotesAsync(Client, Configuration.VehicleID);
    }
}
