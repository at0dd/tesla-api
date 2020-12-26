namespace TeslaAPI.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The ClimateState class.
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

        [JsonProperty("driver_temp_setting")]
        public double DriverTemperatureSetting { get; set; }

        [JsonProperty("fan_status")]
        public int FanStatus { get; set; }

        [JsonProperty("inside_temp")]
        public double InsideTemperature { get; set; }

        [JsonProperty("is_auto_conditioning_on")]
        public bool IsAutoConditioningOn { get; set; }

        [JsonProperty("is_climate_on")]
        public bool IsClimateOn { get; set; }

        [JsonProperty("is_front_defroster_on")]
        public bool IsFrontDefrosterOn { get; set; }

        [JsonProperty("is_preconditioning")]
        public bool IsPreconditioning { get; set; }

        [JsonProperty("is_rear_defroster_on")]
        public bool IsRearDefrosterOn { get; set; }

        [JsonProperty("left_temp_direction")]
        public int LeftTemperatureDirection { get; set; }

        [JsonProperty("max_avail_temp")]
        public double MaximumAvailableTemperature { get; set; }

        [JsonProperty("min_avail_temp")]
        public double MinimumAvailableTemperature { get; set; }

        [JsonProperty("outside_temp")]
        public double OutsideTemperature { get; set; }

        [JsonProperty("passenger_temp_setting")]
        public double PassengerTempSetting { get; set; }

        [JsonProperty("remote_heater_control_enabled")]
        public bool RemoteHeaterControlEnabled { get; set; }

        [JsonProperty("right_temp_direction")]
        public int RightTempDirection { get; set; }

        [JsonProperty("seat_heater_left")]
        public int SeatHeaterLeft { get; set; }

        [JsonProperty("seat_heater_right")]
        public int SeatHeaterRight { get; set; }

        [JsonProperty("side_mirror_heaters")]
        public bool SideMirrorHeaters { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("wiper_blade_heater")]
        public bool WiperBladeHeater { get; set; }
    }
}
