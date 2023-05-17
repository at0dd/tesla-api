namespace Tests;

using Microsoft.Extensions.Options;
using TeslaAPI;
using TeslaAPI.Models.Users;
using Tests.Models;
using Xunit;

public class UsersTests : BaseTests
{
    public UsersTests(IOptions<TeslaConfiguration> teslaConfiguration, ITeslaAPI teslaAPI)
        : base(teslaConfiguration, teslaAPI)
    {
    }

    [Fact]
    public async Task TestGetMeAsync()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            User user = await API.GetMeAsync(Client);
        });
        Assert.Null(exception);
    }

    [Fact]
    public async Task TestGetUserVaultProfileAsync()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            VaultProfile vaultProfile = await API.GetUserVaultProfileAsync(Client);
        });
        Assert.Null(exception);
    }

    [Fact]
    public async Task TestGetUserFeatureConfigAsync()
    {
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            FeatureConfig featureConfig = await API.GetUserFeatureConfigAsync(Client);
        });
        Assert.Null(exception);
    }
}
