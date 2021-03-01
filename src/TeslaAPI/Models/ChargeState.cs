namespace TeslaAPI.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The ChargeState class.
    /// </summary>
    public class ChargeState
    {
        [JsonProperty("battery_heater_on")]
        public bool BatteryHeaterOn { get; set; }

        [JsonProperty("battery_level")]
        public int BatteryLevel { get; set; }

        [JsonProperty("battery_range")]
        public double BatteryRange { get; set; }

        [JsonProperty("charge_current_request")]
        public int ChargeCurrentRequest { get; set; }

        [JsonProperty("charge_current_request_max")]
        public int ChargeCurrentRequestMax { get; set; }

        [JsonProperty("charge_enable_request")]
        public bool ChargeEnableRequest { get; set; }

        [JsonProperty("charge_energy_added")]
        public double ChargeEnergyAdded { get; set; }

        [JsonProperty("charge_limit_soc")]
        public int ChargeLimitStateOfCharge { get; set; }

        [JsonProperty("charge_limit_soc_max")]
        public int ChartLimitStateOfChargeMaximum { get; set; }

        [JsonProperty("charge_limit_soc_min")]
        public int ChargeLimitStateOfChargeMinimum { get; set; }

        [JsonProperty("charge_limit_soc_std")]
        public int ChargeLimitStateOfChargeStandard { get; set; }

        [JsonProperty("charge_miles_added_ideal")]
        public double ChargeMilesAddedIdeal { get; set; }

        [JsonProperty("charge_miles_added_rated")]
        public double ChargeMilesAddedRated { get; set; }

        [JsonProperty("charge_port_cold_weather_mode")]
        public bool? ChargePortColdWeatherMode { get; set; }

        [JsonProperty("charge_port_door_open")]
        public bool ChargePortDoorOpen { get; set; }

        [JsonProperty("charge_port_latch")]
        public string ChargePortLatch { get; set; }

        [JsonProperty("charge_rate")]
        public double ChargeRate { get; set; }

        [JsonProperty("charge_to_max_range")]
        public bool ChargeToMaxRange { get; set; }

        [JsonProperty("charger_actual_current")]
        public int ChargerActualCurrent { get; set; }

        [JsonProperty("charger_phases")]
        public string? ChargerPhases { get; set; }

        [JsonProperty("charger_pilot_current")]
        public int ChargerPilotCurrent { get; set; }

        [JsonProperty("charger_power")]
        public int ChargerPower { get; set; }

        [JsonProperty("charger_voltage")]
        public int ChargerVoltage { get; set; }

        [JsonProperty("charging_state")]
        public string ChargingState { get; set; }

        [JsonProperty("conn_charge_cable")]
        public string ConnChargeCable { get; set; }

        [JsonProperty("est_battery_range")]
        public double EstBatteryRange { get; set; }

        [JsonProperty("fast_charger_brand")]
        public string FastChargerBrand { get; set; }

        [JsonProperty("fast_charger_present")]
        public bool FastChargerPresent { get; set; }

        [JsonProperty("fast_charger_type")]
        public string FastChargerType { get; set; }

        [JsonProperty("ideal_battery_range")]
        public double IdealBatteryRange { get; set; }

        [JsonProperty("managed_charging_active")]
        public bool ManagedChargingActive { get; set; }

        [JsonProperty("managed_charging_start_time")]
        public string? ManagedChargingStartTime { get; set; }

        [JsonProperty("managed_charging_user_canceled")]
        public bool ManagedChargingUserCanceled { get; set; }

        [JsonProperty("max_range_charge_counter")]
        public int MaxRangeChargeCounter { get; set; }

        [JsonProperty("minutes_to_full_charge")]
        public int MinutesToFullCharge { get; set; }

        [JsonProperty("not_enough_power_to_heat")]
        public bool? NotEnoughPowerToHeat { get; set; }

        [JsonProperty("scheduled_charging_pending")]
        public bool ScheduledChargingPending { get; set; }

        [JsonProperty("scheduled_charging_start_time")]
        public string? ScheduledChargingStartTime { get; set; }

        [JsonProperty("time_to_full_charge")]
        public double TimeToFullCharge { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("trip_charging")]
        public bool TripCharging { get; set; }

        [JsonProperty("usable_battery_level")]
        public int UsableBatteryLevel { get; set; }

        [JsonProperty("user_charge_enable_request")]
        public string? UserChargeEnableRequest { get; set; }
    }
}
