namespace Tesla.Tests
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Tesla.API;
    using Tesla.API.Models;
    using Xunit;

    public class IntegrationTests
    {
        private readonly string _bearerToken = "";

        private readonly ITeslaAPI _teslaAPI;
        private readonly HttpClient _client = new HttpClient();

        public IntegrationTests(ITeslaAPI teslaAPI)
        {
            _teslaAPI = teslaAPI;
            _client.DefaultRequestHeaders.Add("User-Agent", "TeslaAPIIntegrationTests");
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_bearerToken}");
        }

        [Fact]
        public async Task TestGetAllVehiclesAsync()
        {
            List<Vehicle> response = await _teslaAPI.GetAllVehiclesAsync(_client);
        }
    }
}