namespace TeslaAPI.Models.Response
{
    using Newtonsoft.Json;

    /// <summary>
    /// The ErrorResponse class.
    /// </summary>
    public class ErrorResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
