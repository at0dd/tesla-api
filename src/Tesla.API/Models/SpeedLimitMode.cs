namespace Tesla.API.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The SpeedLimitMode class.
    /// </summary>
    public class SpeedLimitMode
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("current_limit_mph")]
        public double CurrentLimitMilesPerHour { get; set; }

        [JsonProperty("max_limit_mph")]
        public double MaximumLimitMilesPerHour { get; set; }

        [JsonProperty("min_limit_mph")]
        public double MinimumLimitMilesPerHour { get; set; }

        [JsonProperty("pin_code_set")]
        public bool PINCodeSet { get; set; }
    }
}
