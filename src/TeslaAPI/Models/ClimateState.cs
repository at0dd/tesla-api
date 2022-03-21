namespace TeslaAPI.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Information on the current internal temperature and climate control system.
    /// </summary>
    public class ClimateState
    {
        [JsonProperty("battery_heater")]
        public bool BatteryHeater { get; set; }

        [JsonProperty("battery_heater_no_power")]
        public bool BatteryHeaterNoPower { get; set; }

        [JsonProperty("climate_keeper_mode")]
        public string ClimateKeeperMode { get; set; }

        [JsonProperty("defrost_mode")]
        public int DefrostMode { get; set; }

        /// <summary>
        /// Gets or sets the driver temperature setting.
        /// </summary>
        [JsonProperty("driver_temp_setting")]
        public double DriverTemperatureSetting { get; set; }

        [JsonProperty("fan_status")]
        public int FanStatus { get; set; }

        /// <summary>
        /// Gets or sets the temperature inside the vehicle.
        /// </summary>
        [JsonProperty("inside_temp")]
        public double? InsideTemperature { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether auto conditioning is on.
        /// </summary>
        [JsonProperty("is_auto_conditioning_on")]
        public bool? IsAutoConditioningOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether climate is on.
        /// </summary>
        [JsonProperty("is_climate_on")]
        public bool IsClimateOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the front defroster is on.
        /// </summary>
        [JsonProperty("is_front_defroster_on")]
        public bool IsFrontDefrosterOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the vehicle is preconditioning.
        /// </summary>
        [JsonProperty("is_preconditioning")]
        public bool IsPreconditioning { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether rear defroster is on.
        /// </summary>
        [JsonProperty("is_rear_defroster_on")]
        public bool IsRearDefrosterOn { get; set; }

        [JsonProperty("left_temp_direction")]
        public int? LeftTemperatureDirection { get; set; }

        [JsonProperty("max_avail_temp")]
        public double MaximumAvailableTemperature { get; set; }

        [JsonProperty("min_avail_temp")]
        public double MinimumAvailableTemperature { get; set; }

        /// <summary>
        /// Gets or sets the temperature outside the vehicle.
        /// </summary>
        [JsonProperty("outside_temp")]
        public double? OutsideTemperature { get; set; }

        /// <summary>
        /// Gets or sets the passenger temperature setting.
        /// </summary>
        [JsonProperty("passenger_temp_setting")]
        public double PassengerTempSetting { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether remote heating control is enabled.
        /// </summary>
        [JsonProperty("remote_heater_control_enabled")]
        public bool RemoteHeaterControlEnabled { get; set; }

        [JsonProperty("right_temp_direction")]
        public int? RightTempDirection { get; set; }

        [JsonProperty("seat_heater_left")]
        public int SeatHeaterLeft { get; set; }

        [JsonProperty("seat_heater_right")]
        public int SeatHeaterRight { get; set; }

        [JsonProperty("side_mirror_heaters")]
        public bool SideMirrorHeaters { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the response.
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("wiper_blade_heater")]
        public bool WiperBladeHeater { get; set; }

        [JsonProperty("allow_cabin_overheat_protection")]
        public bool AllowCabinOverheatProtection { get; set; }

        [JsonProperty("bioweapon_mode")]
        public bool BioweaponMode { get; set; }

        [JsonProperty("cabin_overheat_protection")]
        public string CabinOverheatProtection { get; set; }

        [JsonProperty("hvac_auto_request")]
        public string HvacAutoRequest { get; set; }

        [JsonProperty("seat_heater_rear_center")]
        public int SeatHeaterRearCenter { get; set; }

        [JsonProperty("seat_heater_rear_left")]
        public int SeatHeaterRearLeft { get; set; }

        [JsonProperty("seat_heater_rear_right")]
        public int SeatHeaterRearRight { get; set; }

        [JsonProperty("steering_wheel_heater")]
        public bool SteeringWheelHeater { get; set; }

        [JsonProperty("supports_fan_only_cabin_overheat_protection")]
        public bool SupportsFanOnlyCabinOverheatProtection { get; set; }
    }
}
