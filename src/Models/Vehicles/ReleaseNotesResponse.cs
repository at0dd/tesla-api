namespace TeslaAPI.Models.Vehicles
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ReleaseNotesResponse
    {
        [JsonProperty("release_notes")]
        public List<ReleaseNote> ReleaseNotes { get; set; } = new List<ReleaseNote>();

        [JsonProperty("deployed_version")]
        public string DeployedVersion { get; set; }

        [JsonProperty("staged_version")]
        public string? StagedVersion { get; set; }
    }
}
