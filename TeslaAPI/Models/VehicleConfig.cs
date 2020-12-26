namespace TeslaAPI.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The VehicleConfig class.
    /// </summary>
    public class VehicleConfig
    {
        [JsonProperty("can_accept_navigation_requests")]
        public bool CanAcceptNavigationRequests { get; set; }

        [JsonProperty("can_actuate_trunks")]
        public bool CanActuateTrunks { get; set; }

        [JsonProperty("car_special_type")]
        public string CarSpecialType { get; set; }

        [JsonProperty("car_type")]
        public string CarType { get; set; }

        [JsonProperty("charge_port_type")]
        public string ChargePortType { get; set; }

        [JsonProperty("ece_restrictions")]
        public bool ECERestrictions { get; set; }

        [JsonProperty("eu_vehicle")]
        public bool EuropeanUnionVehicle { get; set; }

        [JsonProperty("exterior_color")]
        public string ExteriorColor { get; set; }

        [JsonProperty("has_air_suspension")]
        public bool HasAirSuspension { get; set; }

        [JsonProperty("has_ludicrous_mode")]
        public bool HasLudicrousMode { get; set; }

        [JsonProperty("motorized_charge_port")]
        public bool MotorizedChargePort { get; set; }

        [JsonProperty("plg")]
        public bool PowerLiftGate { get; set; }

        [JsonProperty("rear_seat_heaters")]
        public int RearSeatHeaters { get; set; }

        [JsonProperty("rear_seat_type")]
        public int RearSeatType { get; set; }

        [JsonProperty("rhd")]
        public bool RHD { get; set; }

        [JsonProperty("roof_color")]
        public string RoofColor { get; set; }

        [JsonProperty("seat_type")]
        public int SeatType { get; set; }

        [JsonProperty("spoiler_type")]
        public string SpoilerType { get; set; }

        [JsonProperty("sun_roof_installed")]
        public int SunroofInstalled { get; set; }

        [JsonProperty("third_row_seats")]
        public string ThirdRowSeats { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("trim_badging")]
        public string TrimBadging { get; set; }

        [JsonProperty("use_range_badging")]
        public bool UseRangeBadging { get; set; }

        [JsonProperty("wheel_type")]
        public string WheelType { get; set; }
    }
}
