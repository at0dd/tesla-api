namespace Tesla.API.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The driving and position state of the vehicle.
    /// </summary>
    public class DriveState
    {
        [JsonProperty("gps_as_of")]
        public long GPSAsOf { get; set; }

        [JsonProperty("heading")]
        public int Heading { get; set; }

        /// <summary>
        /// Gets or sets the current latitude.
        /// </summary>
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the current longitude.
        /// </summary>
        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("native_latitude")]
        public double NativeLatitude { get; set; }

        [JsonProperty("native_location_supported")]
        public bool NativeLocationSupported { get; set; }

        [JsonProperty("native_longitude")]
        public double NativeLongitude { get; set; }

        [JsonProperty("native_type")]
        public string NativeType { get; set; }

        [JsonProperty("power")]
        public int Power { get; set; }

        [JsonProperty("shift_state")]
        public string? ShiftState { get; set; }

        /// <summary>
        /// Gets or sets the current speed.
        /// </summary>
        [JsonProperty("speed")]
        public string? Speed { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the response.
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
