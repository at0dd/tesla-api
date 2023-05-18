namespace TeslaAPI.Models.Engery
{
    using Newtonsoft.Json;

    public class Tariff
    {
        [JsonProperty("tariffID")]
        public string TariffID { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("utility")]
        public string Utility { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
