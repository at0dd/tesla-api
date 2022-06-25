namespace Tesla.API.Models.Response
{
    using Newtonsoft.Json;

    /// <summary>
    /// A rollup of all the data_request endpoints plus vehicle configuration.
    /// Note: all *_range values are in miles, irrespective of GUI configuration.
    /// </summary>
    public class VehicleDataResponse : Vehicle
    {
        /// <summary>
        /// Gets or sets the vehicle drive state.
        /// </summary>
        [JsonProperty("drive_state")]
        public DriveState DriveState { get; set; }

        /// <summary>
        /// Gets or sets the vehicle climate state.
        /// </summary>
        [JsonProperty("climate_state")]
        public ClimateState ClimateState { get; set; }

        /// <summary>
        /// Gets or sets the vehicle charge state.
        /// </summary>
        [JsonProperty("charge_state")]
        public ChargeState ChargeState { get; set; }

        /// <summary>
        /// Gets or sets the vehicle GUI settings.
        /// </summary>
        [JsonProperty("gui_settings")]
        public GUISettings GUISettings { get; set; }

        /// <summary>
        /// Gets or sets the vehicle state.
        /// </summary>
        [JsonProperty("vehicle_state")]
        public VehicleState VehicleState { get; set; }

        /// <summary>
        /// Gets or sets the vehicle configuration.
        /// </summary>
        [JsonProperty("vehicle_config")]
        public VehicleConfig VehicleConfig { get; set; }
    }
}
