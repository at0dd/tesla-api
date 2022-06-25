namespace Tesla.API.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The Supercharger class.
    /// </summary>
    public class Supercharger : Charger
    {
        /// <summary>
        /// Gets or sets the number of available stalls at the supercharger.
        /// </summary>
        [JsonProperty("available_stalls")]
        public int AvailableStalls { get; set; }

        /// <summary>
        /// Gets or sets the total number of stalls at the supercharger.
        /// </summary>
        [JsonProperty("total_stalls")]
        public int TotalStalls { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the supercharger is closed or not.
        /// </summary>
        [JsonProperty("site_closed")]
        public bool SiteClosed { get; set; }
    }
}
