namespace TeslaAPI.Models.Engery
{
    using Newtonsoft.Json;

    public class EnergySite
    {
        [JsonProperty("energy_site_id")]
        public long EnergySiteID { get; set; }

        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }

        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("asset_site_id")]
        public string AssetSiteID { get; set; }

        [JsonProperty("solar_power")]
        public int SolarPower { get; set; }

        [JsonProperty("solar_type")]
        public string SolarType { get; set; }

        [JsonProperty("sync_grid_alert_enabled")]
        public bool SyncGridAlertEnabled { get; set; }

        [JsonProperty("breaker_alert_enabled")]
        public bool BreakerAlertEnabled { get; set; }

        [JsonProperty("components")]
        public EnergySiteComponents Components { get; set; }
    }

    public class EnergySiteComponents
    {
        [JsonProperty("battery")]
        public bool Battery { get; set; }

        [JsonProperty("solar")]
        public bool Solar { get; set; }

        [JsonProperty("solar_type")]
        public string SolarType { get; set; }

        [JsonProperty("grid")]
        public bool Grid { get; set; }

        [JsonProperty("load_meter")]
        public bool LoadMeter { get; set; }

        [JsonProperty("market_type")]
        public string MarketType { get; set; }
    }
}
