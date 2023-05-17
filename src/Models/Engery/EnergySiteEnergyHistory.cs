namespace TeslaAPI.Models.Engery
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class EnergySiteEnergyHistory
    {
        [JsonProperty("serial_number")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the period of time the TimeSeries spans over.
        /// "day", "week", "month", "year".
        /// </summary>
        [JsonProperty("period")]
        public string Period { get; set; }

        /// <summary>
        /// Gets or sets entries for the period.
        /// For example, if the period value is week, there are 7 entries, each one representing the energy generated for one day.
        /// </summary>
        [JsonProperty("time_series")]
        public List<EnergySiteEnergyHistoryTime> TimeSeries { get; set; } = new List<EnergySiteEnergyHistoryTime>();
    }
}
