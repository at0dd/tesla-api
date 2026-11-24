namespace Tests;

using Newtonsoft.Json;
using TeslaAPI.Models.Response;
using TeslaAPI.Models.Vehicles;

public class DeserializerTests
{
    [Test]
    [Arguments("responses/vehicle_data/20240923.json")]
    public async Task VehicleData(string path)
    {
        string json = await File.ReadAllTextAsync(Path.Combine(AppContext.BaseDirectory, path));

        VehicleData? data = JsonConvert.DeserializeObject<Response<VehicleData>>(json)?.Data;

        await Assert.That(data).IsNotNull();
    }
}
