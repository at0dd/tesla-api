namespace TeslaAPI.Models.Users
{
    using Newtonsoft.Json;

    public class FeatureConfig
    {
        [JsonProperty("signaling")]
        public FeatureConfigSignaling Signaling { get; set; }
    }

    public class FeatureConfigSignaling
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("subscribe_connectivity")]
        public bool SubscribeConnectivity { get; set; }
    }
}
