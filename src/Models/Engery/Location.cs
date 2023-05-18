namespace TeslaAPI.Models.Engery
{
    using Newtonsoft.Json;

    public class Location
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}
