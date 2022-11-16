namespace Tests;

using Microsoft.Extensions.Options;
using TeslaAPI;
using Tests.Models;

public class BaseTests
{
    public readonly HttpClient Client;
    public readonly ITeslaAPI API;

    public BaseTests(IOptions<TeslaConfiguration> teslaConfiguration, ITeslaAPI teslaAPI)
    {
        API = teslaAPI;

        Client = new HttpClient();
        Client.DefaultRequestHeaders.Add("User-Agent", "Tests");
        Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {teslaConfiguration.Value.AccessToken}");
    }
}
