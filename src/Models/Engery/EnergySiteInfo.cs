namespace TeslaAPI.Models.Engery
{
    using System;
    using Newtonsoft.Json;

    public class EnergySiteInfo
    {
        [JsonProperty("id")]
        public Guid ID { get; set; }

        [JsonProperty("site_name")]
        public string SiteName { get; set; }

        [JsonProperty("site_number")]
        public long SiteNumber { get; set; }

        [JsonProperty("installation_date")]
        public DateTime InstallationDate { get; set; }

        [JsonProperty("user_settings")]
        public UserSettings UserSettings { get; set; }

        [JsonProperty("components")]
        public Components Components { get; set; }

        [JsonProperty("installation_time_zone")]
        public string InstallationTimeZone { get; set; }

        [JsonProperty("time_zone_offset")]
        public int TimeZoneOffset { get; set; }

        [JsonProperty("geolocation")]
        public Location Location { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}
