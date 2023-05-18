namespace TeslaAPI.Models.Engery
{
    using Newtonsoft.Json;

    public class EnergySiteComponents
    {
        [JsonProperty("battery")]
        public bool Battery { get; set; }

        [JsonProperty("solar")]
        public bool Solar { get; set; }

        [JsonProperty("solar_type")]
        public string SolarType { get; set; }

        [JsonProperty("grid")]
        public bool Grid { get; set; }

        [JsonProperty("load_meter")]
        public bool LoadMeter { get; set; }

        [JsonProperty("market_type")]
        public string MarketType { get; set; }
    }
}
