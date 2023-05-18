namespace TeslaAPI.Models.TripPlanner
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A planned trip/route.
    /// </summary>
    public class Trip
    {
        /// <summary>
        /// Gets or sets the state of energy (charing) at the destination.
        /// </summary>
        [JsonProperty("destination_soe")]
        public double DestinationSOE { get; set; }

        /// <summary>
        /// Gets or sets the state of energy (charing) at the origin.
        /// </summary>
        [JsonProperty("origin_soe")]
        public double OriginSOE { get; set; }

        /// <summary>
        /// Gets or sets data representing the trip path.
        /// </summary>
        [JsonProperty("polylines")]
        public List<string> Polylines { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the status of the trip.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets a list of stop along the trip.
        /// </summary>
        [JsonProperty("stops")]
        public List<Stop> Stops { get; set; } = new List<Stop>();

        /// <summary>
        /// Gets or sets the amount of time in seconds needed to charge during the trip.
        /// </summary>
        [JsonProperty("total_charge_dur_s")]
        public double TotalChargeDurationSeconds { get; set; }

        /// <summary>
        /// Gets or sets the amount of kWh needed from charging during the trip.
        /// </summary>
        [JsonProperty("total_charge_kWh")]
        public double TotalChargeKWH { get; set; }

        /// <summary>
        /// Gets or sets the amount of time in seconds spent driving during the trip.
        /// </summary>
        [JsonProperty("total_drive_dur_s")]
        public double TotalDriveDurationSeconds { get; set; }

        /// <summary>
        /// Gets or sets the amount of kWh needed for the trip.
        /// </summary>
        [JsonProperty("total_drive_kWh")]
        public double TotalDriveKWH { get; set; }

        /// <summary>
        /// Gets or sets the amount of miles the trip covers.
        /// </summary>
        [JsonProperty("total_drive_mi")]
        public double TotalDriveMiles { get; set; }
    }
}
