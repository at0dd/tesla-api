namespace TeslaAPI.Models.Vehicles
{
    using Newtonsoft.Json;

    /// <summary>
    /// Various information about the GUI settings of the car, such as unit format and range display.
    /// </summary>
    public class GUISettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether the time is displayed in 24 hours.
        /// </summary>
        [JsonProperty("gui_24_hour_time")]
        public bool GUI24HourTime { get; set; }

        [JsonProperty("gui_charge_rate_units")]
        public string GUIChargeRateUnits { get; set; }

        /// <summary>
        /// Gets or sets the distance units (miles/kilometers).
        /// </summary>
        [JsonProperty("gui_distance_units")]
        public string GUIDistanceUnits { get; set; }

        /// <summary>
        /// Gets or sets the range display (percent/range).
        /// </summary>
        [JsonProperty("gui_range_display")]
        public string GUIRangeDisplay { get; set; }

        /// <summary>
        /// Gets or sets the temperature units (F/C).
        /// </summary>
        [JsonProperty("gui_temperature_units")]
        public string GUITemperatureUnits { get; set; }

        /// <summary>
        /// Gets or sets the tire pressure units (PSI/BAR).
        /// </summary>
        [JsonProperty("gui_tirepressure_units")]
        public string GUITirePressureUnits { get; set; }

        [JsonProperty("show_range_units")]
        public bool ShowRangeUnits { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the response.
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
