namespace TeslaAPI.Models.Engery
{
    using System;
    using Newtonsoft.Json;

    public class EnergySiteStatus
    {
        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }

        [JsonProperty("asset_site_id")]
        public Guid AssetSiteID { get; set; }

        [JsonProperty("solar_power")]
        public int SolarPower { get; set; }

        [JsonProperty("solar_type")]
        public string SolarType { get; set; }

        [JsonProperty("storm_mode_enabled")]
        public bool? StormModeEnabled { get; set; }

        [JsonProperty("powerwall_onboarding_settings_set")]
        public bool? PowerwallOnboardingSettingsSet { get; set; }

        [JsonProperty("sync_grid_alert_enabled")]
        public bool SyncGridAlertEnabled { get; set; }

        [JsonProperty("breaker_alert_enabled")]
        public bool BreakerAlertEnabled { get; set; }
    }
}
