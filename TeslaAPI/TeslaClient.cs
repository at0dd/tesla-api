namespace TeslaAPI
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using TeslaAPI.Models;
    using TeslaAPI.Models.Response;

    /// <summary>
    /// The TeslaClient interface.
    /// </summary>
    public interface ITeslaClient
    {
        /// <summary>
        /// Authenticate with the Tesla API to get an access token.
        /// </summary>
        /// <param name="clientID">The Tesla client ID.</param>
        /// <param name="clientSecret">The Tesla client secret.</param>
        /// <param name="email">The user's email address.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>Returns a <see cref="TeslaAccessToken"/>.</returns>
        public TeslaAccessToken GetAccessToken(string clientID, string clientSecret, string email, string password);

        /// <summary>
        /// Refresh an access token.
        /// </summary>
        /// <param name="clientID">The Tesla client ID.</param>
        /// <param name="clientSecret">The Tesla client secret.</param>
        /// <param name="refreshToken">The exising refresh token.</param>
        /// <returns>Returns a new <see cref="TeslaAccessToken"/>.</returns>
        public TeslaAccessToken RefreshToken(string clientID, string clientSecret, string refreshToken);

        /// <summary>
        /// Get all <see cref="Vehicle"/>s in the user's Tesla account.
        /// </summary>
        /// <param name="accessToken">The user's access token.</param>
        /// <returns>Returns a list of <see cref="Vehicle"/>s.</returns>
        public List<Vehicle> GetAllVehicles(string accessToken);

        /// <summary>
        /// Get all <see cref="Vehicle"/> by its ID.
        /// </summary>
        /// <param name="accessToken">The user's access token.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/> to get.</param>
        /// <returns>Returns the <see cref="Vehicle"/>.</returns>
        public Vehicle GetVehicle(string accessToken, string vehicleID);
    }

    /// <summary>
    /// The TeslaClient class.
    /// </summary>
    public class TeslaClient : ITeslaClient
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string _ownerApiBaseUrl = "https://owner-api.teslamotors.com/api/v1";

        /// <summary>
        /// Initializes a new instance of the <see cref="TeslaClient"/> class.
        /// </summary>
        /// <param name="userAgent">Your application identifier.</param>
        public TeslaClient(string userAgent)
        {
            _client.DefaultRequestHeaders.Add("User-Agent", userAgent);
        }

        /// <inheritdoc/>
        public TeslaAccessToken GetAccessToken(string clientID, string clientSecret, string email, string password)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "client_id", clientID },
                { "client_secret", clientSecret },
                { "email", email },
                { "password", password },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}/oauth/token", body: body);
            return SendRequest<TeslaAccessToken>(request).Result;
        }

        /// <inheritdoc/>
        public TeslaAccessToken RefreshToken(string clientID, string clientSecret, string refreshToken)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "grant_type", "refresh_token" },
                { "client_id", clientID },
                { "client_secret", clientSecret },
                { "refresh_token", refreshToken },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}/oauth/token", body: body);
            return SendRequest<TeslaAccessToken>(request).Result;
        }

        /// <inheritdoc/>
        public List<Vehicle> GetAllVehicles(string accessToken)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}/vehicles", accessToken);
            return SendRequest<ListResponse<Vehicle>>(request).Result.Data;
        }

        /// <inheritdoc/>
        public Vehicle GetVehicle(string accessToken, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}/vehicles/{vehicleID}", accessToken);
            return SendRequest<Response<Vehicle>>(request).Result.Data;
        }

        /// <summary>
        /// Build a <see cref="HttpRequestMessage"/> to send to the API.
        /// </summary>
        /// <param name="method">POST, GET, PUT, DELETE.</param>
        /// <param name="url">The request URL.</param>
        /// <param name="accessToken">The user's access token.</param>
        /// <param name="body">The request body.</param>
        /// <returns>Returns the build request message.</returns>
        private static HttpRequestMessage BuildRequest(HttpMethod method, string url, string accessToken = null, Dictionary<string, string> body = null)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(url),
            };

            if (accessToken != null)
            {
                request.Headers.Add("Authorization", $"Bearer {accessToken}");
            }

            if (body != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            }

            return request;
        }

        /// <summary>
        /// Send a request to the API and return the response.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to send.</param>
        /// <returns>Returns the response <see cref="Task"/>.</returns>
        private async Task<T> SendRequest<T>(HttpRequestMessage request)
        {
            HttpResponseMessage response = await _client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}
