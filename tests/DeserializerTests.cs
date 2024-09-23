namespace Tests;

using Newtonsoft.Json;
using TeslaAPI.Models.Response;
using Xunit;

public class DeserializerTests
{
    [Theory]
    [InlineData("responses/vehicle_data/20240923.json")]
    public void VehicleData(string path)
    {
        string json = File.ReadAllText(path);
        _ = JsonConvert.DeserializeObject<Response<VehicleData>>(json);
    }
}
