namespace TeslaAPI.Models.Vehicles
{
    using Newtonsoft.Json;

    /// <summary>
    /// The vehicle's configuration information including model, color, badging and wheels.
    /// </summary>
    public class VehicleConfig
    {
        [JsonProperty("aux_park_lamps")]
        public string AuxiliaryParkLamps { get; set; }

        [JsonProperty("badge_version")]
        public int BadgeVersion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the vehicle can accept navigation requests.
        /// </summary>
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

        [JsonProperty("cop_user_set_temp_supported")]
        public bool CabinOverheatProtectionUserSetTemperatureSupported { get; set; }

        [JsonProperty("dashcam_clip_save_supported")]
        public bool DashcamClipSaveSupported { get; set; }

        [JsonProperty("default_charge_to_max")]
        public bool DefaultChargeToMax { get; set; }

        [JsonProperty("driver_assist")]
        public string DriverAssist { get; set; }

        [JsonProperty("ece_restrictions")]
        public bool ECERestrictions { get; set; }

        [JsonProperty("efficiency_package")]
        public string EfficiencyPackage { get; set; }

        [JsonProperty("eu_vehicle")]
        public bool EuropeanUnionVehicle { get; set; }

        /// <summary>
        /// Gets or sets the exterior color.
        /// </summary>
        [JsonProperty("exterior_color")]
        public string ExteriorColor { get; set; }

        /// <summary>
        /// Gets or sets the exterior trim color.
        /// </summary>
        [JsonProperty("exterior_trim")]
        public string ExteriorTrim { get; set; }

        /// <summary>
        /// Gets or sets the user entered exterior trim color.
        /// </summary>
        [JsonProperty("exterior_trim_override")]
        public string ExteriorTrimOverride { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the vehicle has air suspension.
        /// </summary>
        [JsonProperty("has_air_suspension")]
        public bool HasAirSuspension { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the vehicle has ludicrous mode.
        /// </summary>
        [JsonProperty("has_ludicrous_mode")]
        public bool HasLudicrousMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the vehicle has seat cooling.
        /// </summary>
        [JsonProperty("has_seat_cooling")]
        public bool HasSeatCooling { get; set; }

        [JsonProperty("headlamp_type")]
        public string HeadlampType { get; set; }

        /// <summary>
        /// Gets or sets the interior trim.
        /// </summary>
        [JsonProperty("interior_trim_type")]
        public string InteriorTrimType { get; set; }

        [JsonProperty("key_version")]
        public int KeyVersion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the vehicle has a motorized charge port.
        /// </summary>
        [JsonProperty("motorized_charge_port")]
        public bool MotorizedChargePort { get; set; }

        /// <summary>
        /// Gets or sets the user entered paint colors.
        /// </summary>
        [JsonProperty("paint_color_override")]
        public string PaintColorOverride { get; set; }

        [JsonProperty("performance_package")]
        public string PerformancePackage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the vehicle has a power lift gate.
        /// </summary>
        [JsonProperty("plg")]
        public bool PowerLiftGate { get; set; }

        [JsonProperty("pws")]
        public bool PedestrianWarningSystem { get; set; }

        [JsonProperty("rear_drive_unit")]
        public string RearDriveUnit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the vehicle has rear seat heaters.
        /// </summary>
        [JsonProperty("rear_seat_heaters")]
        public int RearSeatHeaters { get; set; }

        [JsonProperty("rear_seat_type")]
        public int RearSeatType { get; set; }

        [JsonProperty("rhd")]
        public bool RightHandDrive { get; set; }

        /// <summary>
        /// Gets or sets the color of the vehicles roof.
        /// </summary>
        [JsonProperty("roof_color")]
        public string RoofColor { get; set; }

        [JsonProperty("seat_type")]
        public int? SeatType { get; set; }

        [JsonProperty("spoiler_type")]
        public string SpoilerType { get; set; }

        [JsonProperty("sun_roof_installed")]
        public int? SunroofInstalled { get; set; }

        [JsonProperty("supports_qr_pairing")]
        public bool SupportsQRParing { get; set; }

        [JsonProperty("third_row_seats")]
        public string ThirdRowSeats { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("trim_badging")]
        public string TrimBadging { get; set; }

        [JsonProperty("use_range_badging")]
        public bool UseRangeBadging { get; set; }

        [JsonProperty("utc_offset")]
        public int UTCOffset { get; set; }

        [JsonProperty("webcam_selfie_supported")]
        public bool WebcamSelfieSupported { get; set; }

        [JsonProperty("webcam_supported")]
        public bool WebcamSupported { get; set; }

        [JsonProperty("wheel_type")]
        public string WheelType { get; set; }
    }
}
