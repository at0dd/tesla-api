namespace TeslaAPI.Models.Engery
{
    using System;
    using Newtonsoft.Json;

    public class EnergySiteLiveStatus
    {
        [JsonProperty("solar_power")]
        public int SolarPower { get; set; }

        [JsonProperty("energy_left")]
        public int EnergyLeft { get; set; }

        [JsonProperty("total_pack_energy")]
        public int TotalPackEnergy { get; set; }

        [JsonProperty("percentage_charged")]
        public int PercentageCharged { get; set; }

        [JsonProperty("battery_power")]
        public int BatteryPower { get; set; }

        [JsonProperty("load_power")]
        public double LoadPower { get; set; }

        [JsonProperty("grid_status")]
        public string GridStatus { get; set; }

        [JsonProperty("grid_services_active")]
        public bool GridServicesActive { get; set; }

        [JsonProperty("grid_power")]
        public double GridPower { get; set; }

        [JsonProperty("grid_services_power")]
        public int GridServicesPower { get; set; }

        [JsonProperty("generator_power")]
        public int GeneratorPower { get; set; }

        [JsonProperty("island_status")]
        public string IslandStatus { get; set; }

        [JsonProperty("storm_mode_active")]
        public bool StormModeActivated { get; set; }

        [JsonProperty("timestamp")]
        public DateTime TimeStamp { get; set; }

        [JsonProperty("wall_connectors")]
        public string? WallConnectors { get; set; }
    }
}
