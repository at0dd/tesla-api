namespace Tests;

using Microsoft.Extensions.Options;
using TeslaAPI;
using TeslaAPI.Models.Vehicles;
using Tests.Models;
using Xunit;

public class VehiclesTests : BaseTests
{
    public VehiclesTests(IOptions<TeslaConfiguration> teslaConfiguration, ITeslaAPI teslaAPI)
        : base(teslaConfiguration, teslaAPI)
    {
    }

    [Fact]
    public async Task TestGetAllVehiclesAsync()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            List<Vehicle> vehicles = await API.GetAllVehiclesAsync(Client);
        });
        Assert.Null(exception);
    }

    [Fact]
    public async Task TestGetVehicleAsync()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            Vehicle vehicle = await API.GetVehicleAsync(Client, Configuration.VehicleID);
        });
        Assert.Null(exception);
    }
}
