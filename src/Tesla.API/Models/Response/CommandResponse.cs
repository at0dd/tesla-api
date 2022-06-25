namespace Tesla.API.Models.Response
{
    using Newtonsoft.Json;

    /// <summary>
    /// The CommandResponse class.
    /// </summary>
    public class CommandResponse
    {
        /// <summary>
        /// Gets or sets an explaination for the response.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the result was successful.
        /// </summary>
        [JsonProperty("result")]
        public bool Result { get; set; }
    }
}
