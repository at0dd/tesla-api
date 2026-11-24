namespace Tests;

using TeslaAPI.Models.Vehicles;

public class VehiclesTests : BaseTests
{
    [Test]
    public async Task TestGetAllVehiclesAsync()
    {
        _ = await API.GetAllVehiclesAsync(Client);
    }

    [Test]
    public async Task TestGetVehicleAsync()
    {
        _ = await API.GetVehicleAsync(Client, Configuration.VehicleID);
    }
}
