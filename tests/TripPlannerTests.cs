namespace Tests;

using Microsoft.Extensions.Options;
using TeslaAPI;
using TeslaAPI.Models.TripPlanner;
using Tests.Models;
using Xunit;

public class TripPlannerTests : BaseTests
{
    public TripPlannerTests(IOptions<TeslaConfiguration> teslaConfiguration, ITeslaAPI teslaAPI)
        : base(teslaConfiguration, teslaAPI)
    {
    }

    [Fact(Skip = "Endpoint does not currently work.")]
    public async Task TestRequestTripPlanAsync()
    {
        string destination = "40.6973709,-74.1444848";
        string origin = "34.0200393,-118.7413615";
        double originSOE = 0.64;

        Exception exception = await Record.ExceptionAsync(async () =>
        {
            Trip trip = await API.RequestTripPlanAsync(Client, Configuration.CarTrim, Configuration.CarType, destination, origin, originSOE, Configuration.VIN);
        });
        Assert.Null(exception);
    }
}
