namespace TeslaAPI.Models
{
    /// <summary>
    /// The Charger class.
    /// </summary>
    public class Charger
    {
        public Location Location { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public double DistanceMiles { get; set; }
    }
}
