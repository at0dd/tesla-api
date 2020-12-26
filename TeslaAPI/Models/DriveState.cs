namespace TeslaAPI.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The DriveState class.
    /// </summary>
    public class DriveState
    {
        [JsonProperty("gps_as_of")]
        public long GPSAsOf { get; set; }

        [JsonProperty("heading")]
        public int Heading { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

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

        [JsonProperty("speed")]
        public string? Speed { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
