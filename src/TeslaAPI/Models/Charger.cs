namespace TeslaAPI.Models
{
    /// <summary>
    /// The Charger class.
    /// </summary>
    public class Charger
    {
        /// <summary>
        /// Gets or sets the coordinates of the charger.
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Gets or sets the name of the charger.
        /// </summary>
        public string Name { get; set; }

        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the number of miles away you are from the charger.
        /// </summary>
        public double DistanceMiles { get; set; }
    }
}
