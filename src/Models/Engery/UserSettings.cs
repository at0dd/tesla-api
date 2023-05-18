namespace TeslaAPI.Models.Engery
{
    using Newtonsoft.Json;

    public class UserSettings
    {
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
