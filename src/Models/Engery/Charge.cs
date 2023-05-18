namespace TeslaAPI.Models.Engery
{
    using Newtonsoft.Json;

    public class Charge
    {
        [JsonProperty("ALL")]
        public AllCharges All { get; set; }

        [JsonProperty("Summer")]
        public SeasonCharge Summer { get; set; }

        [JsonProperty("Winter")]
        public SeasonCharge Winter { get; set; }
    }

    public class AllCharges
    {
        [JsonProperty("ALL")]
        public int All { get; set; }
    }

    public class SeasonCharge
    {
        [JsonProperty("ON_PEAK")]
        public double OnPeak { get; set; }

        [JsonProperty("PARTIAL_PEAK")]
        public double PartialPeak { get; set; }

        [JsonProperty("OFF_PEAK")]
        public double OffPeak { get; set; }
    }
}
