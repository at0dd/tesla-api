namespace TeslaAPI
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using global::TeslaAPI.Models;
    using global::TeslaAPI.Models.Response;
    using Newtonsoft.Json;

    /// <summary>
    /// The TeslaClient interface.
    /// </summary>
    public interface ITeslaAPI
    {
        /// <summary>
        /// Authenticate with the Tesla API to get an access token.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="clientID">The Tesla client ID.</param>
        /// <param name="clientSecret">The Tesla client secret.</param>
        /// <param name="email">The user's email address.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>Returns a <see cref="TeslaAccessToken"/>.</returns>
        public TeslaAccessToken GetAccessToken(HttpClient client, string clientID, string clientSecret, string email, string password);

        /// <summary>
        /// Refresh an access token.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="clientID">The Tesla client ID.</param>
        /// <param name="clientSecret">The Tesla client secret.</param>
        /// <param name="refreshToken">The exising refresh token.</param>
        /// <returns>Returns a new <see cref="TeslaAccessToken"/>.</returns>
        public TeslaAccessToken RefreshToken(HttpClient client, string clientID, string clientSecret, string refreshToken);

        /// <summary>
        /// Get all <see cref="Vehicle"/>s in the user's Tesla account.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <returns>Returns a list of <see cref="Vehicle"/>s.</returns>
        public List<Vehicle> GetAllVehicles(HttpClient client);

        /// <summary>
        /// Get all <see cref="Vehicle"/> by its ID.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/> to get.</param>
        /// <returns>Returns the <see cref="Vehicle"/>.</returns>
        public Vehicle GetVehicle(HttpClient client, string vehicleID);
    }

    /// <summary>
    /// The TeslaClient class.
    /// </summary>
    public class TeslaAPI : ITeslaAPI
    {
        private readonly string _ownerApiBaseUrl = "https://owner-api.teslamotors.com";
        private readonly string _apiV1 = "/api/1";

        /// <inheritdoc/>
        public TeslaAccessToken GetAccessToken(HttpClient client, string clientID, string clientSecret, string email, string password)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "client_id", clientID },
                { "client_secret", clientSecret },
                { "email", email },
                { "password", password },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}/oauth/token?grant_type=password", body: body);
            return SendRequest<TeslaAccessToken>(client, request).Result;
        }

        /// <inheritdoc/>
        public TeslaAccessToken RefreshToken(HttpClient client, string clientID, string clientSecret, string refreshToken)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "grant_type", "refresh_token" },
                { "client_id", clientID },
                { "client_secret", clientSecret },
                { "refresh_token", refreshToken },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}/oauth/token?grant_type=refresh_token", body);
            return SendRequest<TeslaAccessToken>(client, request).Result;
        }

        /// <inheritdoc/>
        public List<Vehicle> GetAllVehicles(HttpClient client)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles");
            return SendRequest<ListResponse<Vehicle>>(client, request).Result.Data;
        }

        /// <inheritdoc/>
        public Vehicle GetVehicle(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}");
            return SendRequest<Response<Vehicle>>(client, request).Result.Data;
        }

        /// <summary>
        /// Build a <see cref="HttpRequestMessage"/> to send to the API.
        /// </summary>
        /// <param name="method">POST, GET, PUT, DELETE.</param>
        /// <param name="url">The request URL.</param>
        /// <param name="body">The request body.</param>
        /// <returns>Returns the build request message.</returns>
        private static HttpRequestMessage BuildRequest(HttpMethod method, string url, Dictionary<string, string> body = null)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(url),
            };
            request.Headers.Add("Accept", "application/json");

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
        /// <param name="client">The <see cref="HttpClient"/> to send the request with.</param>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to send.</param>
        /// <returns>Returns the response <see cref="Task"/>.</returns>
        private static async Task<T> SendRequest<T>(HttpClient client, HttpRequestMessage request)
        {
            HttpResponseMessage response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync()).Error;
                throw new Exception(errorMessage);
            }

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}
