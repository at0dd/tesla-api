namespace TeslaAPI.Models.Engery
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class EnergySitePowerHistory
    {
        [JsonProperty("serial_number")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets a list of enteries - one entry for each 15 minutes, starting at the beginning (midnight) of the previous day and ending at the current time and day.
        /// The entries cover 24 - 48 hours, depending on when the request is made.
        /// Depending on your equipment, some nighttime samples may be omitted if they are all zeroes.
        /// </summary>
        [JsonProperty("time_series")]
        public List<EnergySitePowerHistoryTime> TimeSeries { get; set; } = new List<EnergySitePowerHistoryTime>();
    }

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
