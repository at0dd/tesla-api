namespace TeslaAPI.Models.Engery
{
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
}
