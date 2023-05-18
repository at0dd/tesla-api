namespace TeslaAPI.Models.Vehicles
{
    using Newtonsoft.Json;

    public class ReleaseNote
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("subtitle")]
        public string? Subtitle { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("customer_version")]
        public string CustomerVersion { get; set; }

        [JsonProperty("image_url")]
        public string? ImageURL { get; set; }
    }
}
