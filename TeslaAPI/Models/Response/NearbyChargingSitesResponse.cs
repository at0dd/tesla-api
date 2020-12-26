namespace TeslaAPI.Models.Response
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// The NearbyChargingSitesResponse class.
    /// </summary>
    public class NearbyChargingSitesResponse
    {
        [JsonProperty("congestion_sync_time_utc_secs")]
        public long CongestionSyncTimeUTCSeconds { get; set; }

        [JsonProperty("destination_charging")]
        public List<Charger> DestinationCharging { get; set; } = new List<Charger>();

        [JsonProperty("superchargers")]
        public List<Supercharger> Superchargers { get; set; } = new List<Supercharger>();

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
