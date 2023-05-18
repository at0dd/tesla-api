namespace TeslaAPI.Models.Vehicles
{
    using Newtonsoft.Json;

    /// <summary>
    /// A destination charger.
    /// </summary>
    public class DestinationCharger
    {
        /// <summary>
        /// Gets or sets the coordinates of the charger.
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }

        /// <summary>
        /// Gets or sets the name of the charger.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets if the charger is a destination or super charger.
        /// Ex. "destination".
        /// Ex. "supercharger".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the number of miles away you are from the charger.
        /// </summary>
        [JsonProperty("distance_miles")]
        public double DistanceMiles { get; set; }
    }
}
