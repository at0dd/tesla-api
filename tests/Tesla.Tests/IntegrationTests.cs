namespace Tesla.Tests
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Tesla.API;
    using Tesla.API.Models;
    using Xunit;

    /// <summary>
    /// Tesla API Integration Tests.
    /// </summary>
    public class IntegrationTests
    {
        private readonly string _bearerToken = "";

        private readonly ITeslaAPI _teslaAPI;
        private readonly HttpClient _client = new HttpClient();

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationTests"/> class.
        /// </summary>
        /// <param name="teslaAPI">The Tesla API library.</param>
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