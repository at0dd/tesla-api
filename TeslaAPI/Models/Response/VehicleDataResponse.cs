namespace TeslaAPI.Models.Response
{
    using Newtonsoft.Json;

    /// <summary>
    /// The VehicleDataResponseClass.
    /// </summary>
    public class VehicleDataResponse : Vehicle
    {
        [JsonProperty("drive_state")]
        public DriveState DriveState { get; set; }

        [JsonProperty("climate_state")]
        public ClimateState ClimateState { get; set; }

        [JsonProperty("charge_state")]
        public ChargeState ChargeState { get; set; }

        [JsonProperty("gui_settings")]
        public GUISettings GUISettings { get; set; }

        [JsonProperty("vehicle_state")]
        public VehicleState VehicleState { get; set; }

        [JsonProperty("vehicle_config")]
        public VehicleConfig VehicleConfig { get; set; }
    }
}
