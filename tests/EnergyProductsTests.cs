namespace Tests;

using Microsoft.Extensions.Options;
using TeslaAPI;
using TeslaAPI.Models.Engery;
using Tests.Models;
using Xunit;

public class EnergyProductsTests : BaseTests
{
    public EnergyProductsTests(IOptions<TeslaConfiguration> teslaConfiguration, ITeslaAPI teslaAPI)
        : base(teslaConfiguration, teslaAPI)
    {
    }

    [Fact(Skip = "Endpoint does not currently work.")]
    [Obsolete]
    public async Task TestGetEnergyProductsAsync()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            List<EnergySite> products = await API.GetEnergyProductsAsync(Client);
        });
        Assert.Null(exception);
    }
}
