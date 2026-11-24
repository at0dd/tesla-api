namespace Tests;

using TeslaAPI.Models.Engery;

public class EnergyProductsTests : BaseTests
{
    [Test]
    [Skip("Endpoint does not currently work.")]
    [Obsolete]
    public async Task TestGetEnergyProductsAsync()
    {
        _ = await API.GetEnergyProductsAsync(Client);
    }
}
