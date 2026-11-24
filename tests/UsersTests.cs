namespace Tests;

using TeslaAPI.Models.Users;

public class UsersTests : BaseTests
{
    [Test]
    public async Task TestGetMeAsync()
    {
        _ = await API.GetMeAsync(Client);
    }

    [Test]
    public async Task TestGetUserVaultProfileAsync()
    {
        _ = await API.GetUserVaultProfileAsync(Client);
    }

    [Test]
    public async Task TestGetUserFeatureConfigAsync()
    {
        _ = await API.GetUserFeatureConfigAsync(Client);
    }
}
