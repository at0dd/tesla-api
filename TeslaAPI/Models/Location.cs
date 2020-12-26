namespace TeslaAPI.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The Location class.
    /// </summary>
    public class Location
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("long")]
        public double Longitude { get; set; }
    }
}
