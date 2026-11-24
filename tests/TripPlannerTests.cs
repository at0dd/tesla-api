namespace Tests;

using TeslaAPI.Models.TripPlanner;

public class TripPlannerTests : BaseTests
{
    [Test]
    [Skip("Endpoint does not currently work.")]
    [Obsolete]
    public async Task TestRequestTripPlanAsync()
    {
        string destination = "40.6973709,-74.1444848";
        string origin = "34.0200393,-118.7413615";
        double originSOE = 0.64;

        _ = await API.RequestTripPlanAsync(Client, Configuration.CarTrim, Configuration.CarType, destination, origin, originSOE, Configuration.VIN);
    }
}
