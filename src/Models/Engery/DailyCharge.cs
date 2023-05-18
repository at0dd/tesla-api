namespace TeslaAPI.Models.Engery
{
    using Newtonsoft.Json;

    public class DailyCharge
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
