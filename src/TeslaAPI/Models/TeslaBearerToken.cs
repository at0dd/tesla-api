namespace TeslaAPI.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The TeslaBearerToken class.
    /// </summary>
    public class TeslaBearerToken
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}