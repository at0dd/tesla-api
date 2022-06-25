namespace Tesla.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Tesla.API;
    using Tesla.API.Models;
    using Xunit;

    /// <summary>
    /// Tesla API Integration Tests.
    /// </summary>
    public class IntegrationTests
    {
        private readonly string _bearerToken;
        private readonly HttpClient _client = new HttpClient();
        private readonly IConfiguration _configuration;
        private readonly ITeslaAPI _teslaAPI;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationTests"/> class.
        /// </summary>
        /// <param name="teslaAPI">The Tesla API library.</param>
        public IntegrationTests(ITeslaAPI teslaAPI)
        {
            _configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", false, false)
               .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, false)
               .AddEnvironmentVariables()
               .Build();

            _bearerToken = _configuration.GetValue<string>("Tesla:BearerToken");
            if (string.IsNullOrWhiteSpace(_bearerToken))
            {
                throw new Exception("Bearer token is missing.");
            }

            _teslaAPI = teslaAPI;
            _client.DefaultRequestHeaders.Add("User-Agent", "TeslaAPIIntegrationTests");
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_bearerToken}");
        }

        [Fact]
        public async Task TestGetAllVehiclesAsync()
        {
            try
            {
                List<Vehicle> response = await _teslaAPI.GetAllVehiclesAsync(_client);
            }
            catch (Exception e)
            {

            }
        }
    }
}