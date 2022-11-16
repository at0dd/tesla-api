namespace Tests;

using Microsoft.Extensions.Options;
using TeslaAPI;
using Tests.Models;

public class BaseTests
{
    public readonly HttpClient Client;
    public readonly ITeslaAPI API;
    public readonly string VehicleID;
    public readonly string EnergySiteID;

    public BaseTests(IOptions<TeslaConfiguration> teslaConfiguration, ITeslaAPI teslaAPI)
    {
        API = teslaAPI;
        TeslaConfiguration config = teslaConfiguration.Value;

        Client = new HttpClient();
        Client.DefaultRequestHeaders.Add("User-Agent", "Tests");
        Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {config.AccessToken}");

        VehicleID = config.VehicleID;
        EnergySiteID = config.EnergySiteID;
    }
}
