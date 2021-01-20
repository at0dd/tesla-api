namespace TeslaAPI.Models.Response
{
    using Newtonsoft.Json;

    /// <summary>
    /// The CommandResponse class.
    /// </summary>
    public class CommandResponse
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("result")]
        public bool Result { get; set; }
    }
}
