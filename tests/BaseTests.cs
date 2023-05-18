namespace Tests;

using Microsoft.Extensions.Options;
using TeslaAPI;
using Tests.Models;

public class BaseTests
{
    public readonly HttpClient Client;
    public readonly ITeslaAPI API;
    public readonly TeslaConfiguration Configuration;

    public BaseTests(IOptions<TeslaConfiguration> teslaConfiguration, ITeslaAPI teslaAPI)
    {
        API = teslaAPI;
        Configuration = teslaConfiguration.Value;

        Client = new HttpClient();
        Client.DefaultRequestHeaders.Add("User-Agent", "Tests");
        Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Configuration.AccessToken}");
    }
}
