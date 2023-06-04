namespace TeslaAPI.Models.Vehicles
{
    using global::TeslaAPI.Enumerators;
    using Newtonsoft.Json;

    /// <summary>
    /// The vehicle's physical state, such as which doors are open.
    /// For the trunk (rt) and frunk (ft) fields, you should interpret a zero (0) value as closed and a non-zero value as open (partially or fully).
    /// </summary>
    public class VehicleState
    {
        /// <summary>
        /// Gets or sets the API version of the vehicle.
        /// </summary>
        [JsonProperty("api_version")]
        public int APIVersion { get; set; }

        [JsonProperty("autopark_state_v2")]
        public string? AutoParkStateV2 { get; set; }

        [JsonProperty("autopark_state_v3")]
        public string? AutoParkStateV3 { get; set; }

        [JsonProperty("autopark_style")]
        public string AutoParkStyle { get; set; }

        [JsonProperty("calendar_supported")]
        public bool CalendarSupported { get; set; }

        [JsonProperty("car_version")]
        public string CarVersion { get; set; }

        /// <summary>
        /// Gets or sets the state of the center display.
        /// </summary>
        [JsonProperty("center_display_state")]
        public CenterDisplayState CenterDisplayState { get; set; }

        [JsonProperty("dashcam_clip_save_available")]
        public bool DashcamClipSaveAvailable { get; set; }

        [JsonProperty("dashcam_state")]
        public string DashcamState { get; set; }

        [JsonProperty("df")]
        public int DriverFront { get; set; }

        [JsonProperty("dr")]
        public int DriverRear { get; set; }

        [JsonProperty("fd_window")]
        public int FrontDriverWindow { get; set; }

        [JsonProperty("feature_bitmask")]
        public string FeatureBitmask { get; set; }

        [JsonProperty("fp_window")]
        public int FrontPassengerWindow { get; set; }

        [JsonProperty("ft")]
        public int FrontTrunk { get; set; }

        [JsonProperty("homelink_device_count")]
        public int HomelinkDeviceCount { get; set; }

        [JsonProperty("homelink_nearby")]
        public bool HomelinkNearby { get; set; }

        [JsonProperty("is_user_present")]
        public bool IsUserPresent { get; set; }

        [JsonProperty("last_autopark_error")]
        public string LastAutoparkError { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        /// <summary>
        /// Gets or sets the media information.
        /// </summary>
        [JsonProperty("media_info")]
        public MediaInfo MediaInfo { get; set; }

        /// <summary>
        /// Gets or sets the media state.
        /// </summary>
        [JsonProperty("media_state")]
        public MediaState MediaState { get; set; }

        [JsonProperty("notifications_supported")]
        public bool NotificationsSupported { get; set; }

        [JsonProperty("odometer")]
        public double Odometer { get; set; }

        [JsonProperty("parsed_calendar_supported")]
        public bool ParsedCalendarSupport { get; set; }

        [JsonProperty("pf")]
        public int PassengerFront { get; set; }

        [JsonProperty("pr")]
        public int PassengerRear { get; set; }

        [JsonProperty("rd_window")]
        public int RearDriverWindow { get; set; }

        [JsonProperty("remote_start")]
        public bool RemoteStart { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether remote start is enabled.
        /// </summary>
        [JsonProperty("remote_start_enabled")]
        public bool RemoteStartEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether remote start is suppored.
        /// </summary>
        [JsonProperty("remote_start_supported")]
        public bool RemoteStartSupported { get; set; }

        [JsonProperty("rp_window")]
        public int RearPassengerWindow { get; set; }

        [JsonProperty("rt")]
        public int RearTrunk { get; set; }

        [JsonProperty("santa_mode")]
        public int SantaMode { get; set; }

        [JsonProperty("sentry_mode")]
        public bool SentryMode { get; set; }

        [JsonProperty("sentry_mode_available")]
        public bool SentryModeAvailable { get; set; }

        [JsonProperty("service_mode")]
        public bool ServiceMode { get; set; }

        [JsonProperty("service_mode_plus")]
        public bool ServiceModePlus { get; set; }

        [JsonProperty("smart_summon_available")]
        public bool SmartSummonAvailable { get; set; }

        /// <summary>
        /// Gets or sets software update information.
        /// </summary>
        [JsonProperty("software_update")]
        public SoftwareUpdate SoftwareUpdate { get; set; }

        /// <summary>
        /// Gets or sets speed limit mode information.
        /// </summary>
        [JsonProperty("speed_limit_mode")]
        public SpeedLimitMode SpeedLimitMode { get; set; }

        [JsonProperty("summon_standby_mode_enabled")]
        public bool SummonStandbyModeEnabled { get; set; }

        /// <summary>
        /// Gets or sets how far the sunroof is open.
        /// </summary>
        [JsonProperty("sun_roof_percent_open")]
        public int? SunRoofPercentOpen { get; set; }

        [JsonProperty("sun_roof_state")]
        public string? SunRoofState { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the tire pressure of the front left tire is too high.
        /// </summary>
        [JsonProperty("tpms_hard_warning_fl")]
        public bool TPMSHardWarningFrontLeft { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the tire pressure of the front right tire is too high.
        /// </summary>
        [JsonProperty("tpms_hard_warning_fr")]
        public bool TPMSHardWarningFrontRight { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the tire pressure of the rear left tire is too high.
        /// </summary>
        [JsonProperty("tpms_hard_warning_rl")]
        public bool TPMSHardWarningRearLeft { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the tire pressure of the rear right tire is too high.
        /// </summary>
        [JsonProperty("tpms_hard_warning_rr")]
        public bool TPMSHardWarningRearRight { get; set; }

        /// <summary>
        /// Gets or sets when the tire pressure of the front left tire was last seen.
        /// </summary>
        [JsonProperty("tpms_last_seen_pressure_time_fl")]
        public long? TPMSLastSeenPressureTimeFrontLeft { get; set; }

        /// <summary>
        /// Gets or sets when the tire pressure of the front right tire was last seen.
        /// </summary>
        [JsonProperty("tpms_last_seen_pressure_time_fr")]
        public long? TPMSLastSeenPressureTimeFrontRight { get; set; }

        /// <summary>
        /// Gets or sets when the tire pressure of the rear left tire was last seen.
        /// </summary>
        [JsonProperty("tpms_last_seen_pressure_time_rl")]
        public long? TPMSLastSeenPressureTimeRearLeft { get; set; }

        /// <summary>
        /// Gets or sets when the tire pressure of the rear right tire was last seen.
        /// </summary>
        [JsonProperty("tpms_last_seen_pressure_time_rr")]
        public long? TPMSLastSeenPressureTimeRearRight { get; set; }

        /// <summary>
        /// Gets or sets the tire pressure of the front left tire.
        /// </summary>
        [JsonProperty("tpms_pressure_fl")]
        public double? TPMSPressureFrontLeft { get; set; }

        /// <summary>
        /// Gets or sets the tire pressure of the front right tire.
        /// </summary>
        [JsonProperty("tpms_pressure_fr")]
        public double? TPMSPressureFrontRight { get; set; }

        /// <summary>
        /// Gets or sets the tire pressure of the rear left tire.
        /// </summary>
        [JsonProperty("tpms_pressure_rl")]
        public double? TPMSPressureRearLeft { get; set; }

        /// <summary>
        /// Gets or sets the tire pressure of the rear right tire.
        /// </summary>
        [JsonProperty("tpms_pressure_rr")]
        public double? TPMSPressureRearRight { get; set; }

        /// <summary>
        /// Gets or sets the recommended cold tire pressure for the front tires.
        /// </summary>
        [JsonProperty("tpms_rcp_front_value")]
        public double TPMSRecommendedColdPressureFrontValue { get; set; }

        /// <summary>
        /// Gets or sets the recommended cold tire pressure for the rear tires.
        /// </summary>
        [JsonProperty("tpms_rcp_rear_value")]
        public double TPMSRecommendedColdPressureRearValue { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the tire pressure of the front left tire is too low.
        /// </summary>
        [JsonProperty("tpms_soft_warning_fl")]
        public bool TPMSSoftWarningFrontLeft { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the tire pressure of the front right tire is too low.
        /// </summary>
        [JsonProperty("tpms_soft_warning_fr")]
        public bool TPMSSoftWarningFrontRight { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the tire pressure of the rear left tire is too low.
        /// </summary>
        [JsonProperty("tpms_soft_warning_rl")]
        public bool TPMSSoftWarningRearLeft { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the tire pressure of the rear right tire is too low.
        /// </summary>
        [JsonProperty("tpms_soft_warning_rr")]
        public bool TPMSSoftWarningRearRight { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether valet mode is enabled.
        /// </summary>
        [JsonProperty("valet_mode")]
        public bool ValetMode { get; set; }

        [JsonProperty("valet_pin_needed")]
        public bool ValetPINNeeded { get; set; }

        /// <summary>
        /// Gets or sets the vehicle name.
        /// </summary>
        [JsonProperty("vehicle_name")]
        public string VehicleName { get; set; }

        [JsonProperty("vehicle_self_test_progress")]
        public int VehicleSelfTestProgress { get; set; }

        [JsonProperty("vehicle_self_test_requested")]
        public bool VehicleSelfTestRequested { get; set; }

        [JsonProperty("webcam_available")]
        public bool WebcamAvailable { get; set; }
    }
}
