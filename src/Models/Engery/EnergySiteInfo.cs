namespace TeslaAPI.Models.Engery
{
    using System;
    using Newtonsoft.Json;

    public class EnergySiteInfo
    {
        // Without Powerwall.
        [JsonProperty("id")]
        public string ID { get; set; }

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

        // With Powerwall.
        [JsonProperty("backup_reserve_percent")]
        public int? BackupReservePercent { get; set; }

        [JsonProperty("default_real_mode")]
        public string? DefaultRealMode { get; set; }

        [JsonProperty("version")]
        public string? Version { get; set; }

        [JsonProperty("battery_count")]
        public int? BatteryCount { get; set; }

        [JsonProperty("tou_settings")]
        public TOUSettings? TOUSettings { get; set; }

        [JsonProperty("nameplate_power")]
        public long? NameplatePower { get; set; }

        [JsonProperty("nameplate_energy")]
        public long? NameplateEnergy { get; set; }

        [JsonProperty("off_grid_vehicle_charging_reserve_percent")]
        public int? OffGridVehicleChargingReservePercent { get; set; }

        [JsonProperty("max_site_meter_power_ac")]
        public long? MaxSiteMeterPowerAC { get; set; }

        [JsonProperty("min_site_meter_power_ac")]
        public long? MinSiteMeterPowerAC { get; set; }
    }
}
