namespace Tesla.API.Models.Response
{
    using Newtonsoft.Json;

    /// <summary>
    /// The ErrorResponse class.
    /// </summary>
    public class ErrorResponse
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
