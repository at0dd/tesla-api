namespace TeslaAPI.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The Location class.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Gets or sets latitude.
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets longitude.
        /// </summary>
        [JsonProperty("long")]
        public double Longitude { get; set; }
    }
}
