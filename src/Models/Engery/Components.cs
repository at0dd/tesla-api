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

        [JsonProperty("energy_service_self_scheduling_enabled")]
        public bool EnergyServiceSelfSchedulingEnabled { get; set; }

        [JsonProperty("rate_plan_manager_supported")]
        public bool RatePlanManagerSupported { get; set; }

        [JsonProperty("configurable")]
        public bool Configurable { get; set; }

        [JsonProperty("grid_services_enabled")]
        public bool GridServicesEnabled { get; set; }
    }
}
