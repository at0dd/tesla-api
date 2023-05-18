namespace TeslaAPI.Models.TripPlanner
{
    using Newtonsoft.Json;

    /// <summary>
    /// A stop along a trip.
    /// </summary>
    public class Stop
    {
        /// <summary>
        /// Gets or sets the address of the stop.
        /// </summary>
        [JsonProperty("addr")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the state of energy (charging) on arrival.
        /// </summary>
        [JsonProperty("arrival_soe")]
        public double ArrivalSOE { get; set; }

        /// <summary>
        /// Gets or sets the amount of time in seconds needed to charge at the stop.
        /// </summary>
        [JsonProperty("charge_dur_s")]
        public double ChargeDurationSeconds { get; set; }

        /// <summary>
        /// Gets or sets the amount of kWh needed.
        /// </summary>
        [JsonProperty("charge_kWh")]
        public double ChargeKWH { get; set; }

        /// <summary>
        /// Gets or sets the ID of the stop.
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the location of the stop.
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }

        /// <summary>
        /// Gets or sets the name of the stop.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ID of the stop in the Tesla Retail Tool.
        /// </summary>
        [JsonProperty("trt_id")]
        public string TRTID { get; set; }
    }
}
