namespace TeslaAPI.Models.Vehicles
{
    using Newtonsoft.Json;

    /// <summary>
    /// Information on the state of charge in the battery and its various settings.
    /// </summary>
    public class ChargeState
    {
        /// <summary>
        /// Gets or sets a value indicating whether the battery heater is on.
        /// </summary>
        [JsonProperty("battery_heater_on")]
        public bool BatteryHeaterOn { get; set; }

        /// <summary>
        /// Gets or sets the battery percent.
        /// </summary>
        [JsonProperty("battery_level")]
        public int BatteryLevel { get; set; }

        /// <summary>
        /// Gets or sets the battery range.
        /// </summary>
        [JsonProperty("battery_range")]
        public double BatteryRange { get; set; }

        /// <summary>
        /// Gets or sets the current charging amperage.
        /// </summary>
        [JsonProperty("charge_amps")]
        public int ChargeAmps { get; set; }

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

        /// <summary>
        /// Gets or sets the color of the charge port.
        /// </summary>
        [JsonProperty("charge_port_color")]
        public string ChargePortColor { get; set; }

        [JsonProperty("charge_port_door_open")]
        public bool ChargePortDoorOpen { get; set; }

        [JsonProperty("charge_port_latch")]
        public string ChargePortLatch { get; set; }

        [JsonProperty("charge_rate")]
        public double ChargeRate { get; set; }

        [JsonProperty("charge_to_max_range")]
        public bool? ChargeToMaxRange { get; set; }

        [JsonProperty("charger_actual_current")]
        public int ChargerActualCurrent { get; set; }

        [JsonProperty("charger_phases")]
        public string? ChargerPhases { get; set; }

        [JsonProperty("charger_pilot_current")]
        public int? ChargerPilotCurrent { get; set; }

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

        /// <summary>
        /// Gets or sets the ideal battery range.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the number of minutes left for a full charge.
        /// </summary>
        [JsonProperty("minutes_to_full_charge")]
        public int MinutesToFullCharge { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the vehicle has enough power left to heat up.
        /// </summary>
        [JsonProperty("not_enough_power_to_heat")]
        public bool? NotEnoughPowerToHeat { get; set; }

        [JsonProperty("off_peak_charging_enabled")]
        public bool OffPeakChargingEnabled { get; set; }

        [JsonProperty("off_peak_charging_times")]
        public string OffPeakChargingTimes { get; set; }

        [JsonProperty("off_peak_hours_end_time")]
        public int OffPeakHoursEndTime { get; set; }

        [JsonProperty("preconditioning_enabled")]
        public bool PreconditioningEnabled { get; set; }

        [JsonProperty("preconditioning_times")]
        public string PreconditioningTimes { get; set; }

        [JsonProperty("scheduled_charging_mode")]
        public string ScheduledChargingMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a scheduled charge is pending.
        /// </summary>
        [JsonProperty("scheduled_charging_pending")]
        public bool ScheduledChargingPending { get; set; }

        /// <summary>
        /// Gets or sets the scheduled charing start time.
        /// </summary>
        [JsonProperty("scheduled_charging_start_time")]
        public string? ScheduledChargingStartTime { get; set; }

        [JsonProperty("scheduled_charging_start_time_app")]
        public int ScheduledChargingStartTimeApp { get; set; }

        [JsonProperty("scheduled_departure_time")]
        public long? ScheduledDepartureTime { get; set; }

        [JsonProperty("scheduled_departure_time_minutes")]
        public int ScheduledDepartureTimeMinutes { get; set; }

        [JsonProperty("supercharger_session_trip_planner")]
        public bool SuperchargerSessionTripPlanner { get; set; }

        /// <summary>
        /// Gets or sets the amount of time left for a full charge.
        /// </summary>
        [JsonProperty("time_to_full_charge")]
        public double TimeToFullCharge { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the response.
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("trip_charging")]
        public bool? TripCharging { get; set; }

        /// <summary>
        /// Gets or sets the usable battery percentage.
        /// </summary>
        [JsonProperty("usable_battery_level")]
        public int UsableBatteryLevel { get; set; }

        [JsonProperty("user_charge_enable_request")]
        public string? UserChargeEnableRequest { get; set; }
    }
}
