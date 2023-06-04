namespace TeslaAPI.Models.Engery
{
    using Newtonsoft.Json;

    public class Components
    {
        [JsonProperty("solar")]
        public bool Solar { get; set; }

        [JsonProperty("solar_type")]
        public string SolarType { get; set; }

        [JsonProperty("battery")]
        public bool Battery { get; set; }

        [JsonProperty("generator")]
        public bool? Generator { get; set; }

        [JsonProperty("grid")]
        public bool Grid { get; set; }

        [JsonProperty("backup")]
        public bool Backup { get; set; }

        [JsonProperty("gateway")]
        public string Gateway { get; set; }

        [JsonProperty("load_meter")]
        public bool LoadMeter { get; set; }

        [JsonProperty("tou_capable")]
        public bool TOUCapable { get; set; }

        [JsonProperty("storm_mode_capable")]
        public bool StormModeCapable { get; set; }

        [JsonProperty("flex_energy_request_capable")]
        public bool FlexEnergyRequestCapable { get; set; }

        [JsonProperty("car_charging_data_supported")]
        public bool CarChargingDataSupported { get; set; }

        [JsonProperty("off_grid_vehicle_charging_reserve_supported")]
        public bool OffGridVehicleChargingReserveSupported { get; set; }

        [JsonProperty("vehicle_charging_performance_view_enabled")]
        public bool VehicleChargingPerformanceViewEnabled { get; set; }

        [JsonProperty("vehicle_charging_solar_offset_view_enabled")]
        public bool VehicleChargingSolarOffsetViewEnabled { get; set; }

        [JsonProperty("battery_solar_offset_view_enabled")]
        public bool BatterySolarOffsetViewEnabled { get; set; }

        [JsonProperty("solar_value_enabled")]
        public bool? SolarViewEnabled { get; set; }

        [JsonProperty("energy_value_header")]
        public string? EnergyValueHeader { get; set; }

        [JsonProperty("energy_value_subheader")]
        public string? EnergyValueSubHeader { get; set; }

        [JsonProperty("energy_service_self_scheduling_enabled")]
        public bool EnergyServiceSelfSchedulingEnabled { get; set; }

        [JsonProperty("show_grid_import_battery_source_cards")]
        public bool? ShowGridImportBatterySourceCards { get; set; }

        [JsonProperty("set_islanding_mode_enabled")]
        public bool? SetIslandingModeEnabled { get; set; }

        [JsonProperty("wifi_commissioning_enabled")]
        public bool? WifiCommissioningEnabled { get; set; }

        [JsonProperty("backup_time_remaining_enabled")]
        public bool? BackupTimeRemainingEnabled { get; set; }

        [JsonProperty("battery_type")]
        public string? BatteryType { get; set; }

        [JsonProperty("rate_plan_manager_supported")]
        public bool RatePlanManagerSupported { get; set; }

        [JsonProperty("configurable")]
        public bool Configurable { get; set; }

        [JsonProperty("grid_services_enabled")]
        public bool GridServicesEnabled { get; set; }

        [JsonProperty("edit_setting_permission_to_export")]
        public bool? EditSettingPermissionToExport { get; set; }

        [JsonProperty("edit_setting_grid_charging")]
        public bool? EditSettingGridCharging { get; set; }

        [JsonProperty("edit_setting_energy_exports")]
        public bool? EditSettingEnergyExports { get; set; }
    }
}
