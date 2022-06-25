﻿namespace Tesla.API.Models.Response
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Returns a list of nearby Tesla-operated charging stations. (Requires car software version 2018.48 or higher.)
    /// </summary>
    public class NearbyChargingSitesResponse
    {
        [JsonProperty("congestion_sync_time_utc_secs")]
        public long CongestionSyncTimeUTCSeconds { get; set; }

        /// <summary>
        /// Gets or sets a list of destination chargers.
        /// </summary>
        [JsonProperty("destination_charging")]
        public List<Charger> DestinationCharging { get; set; } = new List<Charger>();

        /// <summary>
        /// Gets or sets a list of superchargers.
        /// </summary>
        [JsonProperty("superchargers")]
        public List<Supercharger> Superchargers { get; set; } = new List<Supercharger>();

        /// <summary>
        /// Gets or sets the timestamp of the response.
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
