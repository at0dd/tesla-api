namespace TeslaAPI.Models.TripPlanner
{
    using Newtonsoft.Json;

    /// <summary>
    /// Location coordinates.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Gets or sets the latitude of the location.
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the location.
        /// </summary>
        [JsonProperty("lng")]
        public double Longitude { get; set; }
    }
}
