namespace TeslaAPI.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The GUISettings class.
    /// </summary>
    public class GUISettings
    {
        [JsonProperty("gui_24_hour_time")]
        public bool GUI24HourTime { get; set; }

        [JsonProperty("gui_charge_rate_units")]
        public string GUIChargeRateUnits { get; set; }

        [JsonProperty("gui_distance_units")]
        public string GUIDistanceUnits { get; set; }

        [JsonProperty("gui_range_display")]
        public string GUIRangeDisplay { get; set; }

        [JsonProperty("gui_temperature_units")]
        public string GUITemperatureUnits { get; set; }

        [JsonProperty("show_range_units")]
        public bool ShowRangeUnits { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
