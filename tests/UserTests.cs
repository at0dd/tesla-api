namespace Tests;

using Microsoft.Extensions.Options;
using TeslaAPI;
using TeslaAPI.Models.Users;
using Tests.Models;
using Xunit;

public class UserTests : BaseTests
{
    public UserTests(IOptions<TeslaConfiguration> teslaConfiguration, ITeslaAPI teslaAPI)
        : base(teslaConfiguration, teslaAPI)
    {
    }

    [Fact]
    public async Task TestGetMe()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            User user = await API.GetMe(Client);
        });
        Assert.Null(exception);
    }

    [Fact]
    public async Task TestGetUserVaultProfile()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            VaultProfile vaultProfile = await API.GetUserVaultProfile(Client);
        });
        Assert.Null(exception);
    }

    [Fact]
    public async Task GetUserFeatureConfig()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            FeatureConfig featureConfig = await API.GetUserFeatureConfig(Client);
        });
        Assert.Null(exception);
    }
}
