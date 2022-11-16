namespace TeslaAPI.Models.Vehicles
{
    using Newtonsoft.Json;

    /// <summary>
    /// The MediaState class.
    /// </summary>
    public class MediaState
    {
        [JsonProperty("remote_control_enabled")]
        public bool RemoteControlEnabled { get; set; }
    }
}