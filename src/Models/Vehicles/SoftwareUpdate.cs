namespace TeslaAPI.Models.Vehicles
{
    using Newtonsoft.Json;

    /// <summary>
    /// The SoftwareUpdate class.
    /// </summary>
    public class SoftwareUpdate
    {
        [JsonProperty("download_perc")]
        public int DownloadPercent { get; set; }

        [JsonProperty("expected_duration_sec")]
        public int ExpectedDurationSeconds { get; set; }

        [JsonProperty("install_perc")]
        public int InstallPercent { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
