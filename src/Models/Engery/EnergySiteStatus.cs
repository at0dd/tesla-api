namespace TeslaAPI.Models.Engery
{
    using System;
    using Newtonsoft.Json;

    public class EnergySiteStatus
    {
        // Without a powerwall.
        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }

        [JsonProperty("asset_site_id")]
        public Guid? AssetSiteID { get; set; }

        [JsonProperty("solar_power")]
        public int? SolarPower { get; set; }

        [JsonProperty("solar_type")]
        public string? SolarType { get; set; }

        [JsonProperty("storm_mode_enabled")]
        public bool? StormModeEnabled { get; set; }

        [JsonProperty("powerwall_onboarding_settings_set")]
        public bool? PowerwallOnboardingSettingsSet { get; set; }

        [JsonProperty("sync_grid_alert_enabled")]
        public bool SyncGridAlertEnabled { get; set; }

        [JsonProperty("breaker_alert_enabled")]
        public bool BreakerAlertEnabled { get; set; }

        // With a power wall.
        [JsonProperty("site_name")]
        public string? SiteName { get; set; }

        [JsonProperty("gateway_id")]
        public string? GatewayID { get; set; }

        [JsonProperty("energy_left")]
        public long? EnergyLeft { get; set; }

        [JsonProperty("total_pack_energy")]
        public long? TotalPackEnergy { get; set; }

        [JsonProperty("percentage_charged")]
        public int? PercentageCharged { get; set; }

        [JsonProperty("battery_type")]
        public string? BatteryType { get; set; }

        [JsonProperty("backup_capable")]
        public bool? BackupCapable { get; set; }

        [JsonProperty("battery_power")]
        public int? BatteryPower { get; set; }

        // TODO: Unsure of type.
        [JsonProperty("powerwall_tesla_electric_interested_in")]
        public string? PowerwallTeslaElectricInterestedIn { get; set; }
    }
}
