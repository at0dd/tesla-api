namespace TeslaAPI.Models.Engery
{
    using System;
    using Newtonsoft.Json;

    public class EnergySitePowerHistoryTime
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the power being generated, in watts, at the given timestamp.
        /// </summary>
        [JsonProperty("solar_power")]
        public int SolarPower { get; set; }

        [JsonProperty("battery_power")]
        public int BatteryPower { get; set; }

        [JsonProperty("grid_power")]
        public int GridPower { get; set; }

        [JsonProperty("grid_services_power")]
        public int GridServicesPower { get; set; }

        [JsonProperty("generator_power")]
        public int GeneratorPower { get; set; }
    }
}
