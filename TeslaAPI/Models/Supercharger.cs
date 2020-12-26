namespace TeslaAPI.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The Supercharger class.
    /// </summary>
    public class Supercharger : Charger
    {
        [JsonProperty("available_stalls")]
        public int AvailableStalls { get; set; }

        [JsonProperty("total_stalls")]
        public int TotalStalls { get; set; }

        [JsonProperty("site_closed")]
        public bool SiteClosed { get; set; }
    }
}
