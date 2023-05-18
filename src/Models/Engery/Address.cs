namespace TeslaAPI.Models.Engery
{
    using Newtonsoft.Json;

    public class Address
    {
        [JsonProperty("address_line1")]
        public string Address1 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
