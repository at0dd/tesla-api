namespace Tests;

using Microsoft.Extensions.Configuration;
using TeslaAPI;
using Tests.Models;

/// <summary>
/// Base class for live tests, which call the real Tesla API. They are skipped unless
/// appsettings.Development.json sets Tesla:AccessToken, so CI never runs them.
/// </summary>
public abstract class BaseTests
{
    protected BaseTests()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", false, false)
            .AddJsonFile("appsettings.Development.json", true, false)
            .Build();

        Configuration = configuration.GetSection(TeslaConfiguration.SectionName).Get<TeslaConfiguration>() ?? new TeslaConfiguration();
        API = new TeslaAPI();

        Client = new HttpClient();
        Client.DefaultRequestHeaders.Add("User-Agent", "Tests");
        Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Configuration.AccessToken}");
    }

    protected HttpClient Client { get; }

    protected ITeslaAPI API { get; }

    protected TeslaConfiguration Configuration { get; }

    [Before(Test)]
    public void SkipWithoutAccessToken()
    {
        Skip.When(string.IsNullOrWhiteSpace(Configuration.AccessToken), "Live test: set Tesla:AccessToken in appsettings.Development.json to run it.");
    }

    [After(Test)]
    public void DisposeClient()
    {
        Client.Dispose();
    }
}
