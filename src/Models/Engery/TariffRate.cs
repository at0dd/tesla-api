namespace TeslaAPI.Models.Engery
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class TariffRate
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("utility")]
        public string Utility { get; set; }

        [JsonProperty("daily_charges")]
        public List<DailyCharge> DailyCharges { get; set; } = new List<DailyCharge>();

        [JsonProperty("demand_charges")]
        public Charge DemandCharges { get; set; }

        [JsonProperty("energy_charges")]
        public Charge EnergyCharges { get; set; }

        [JsonProperty("seasons")]
        public Seasons Seasons { get; set; }

        [JsonProperty("sell_tariff")]
        public TariffRate? SellTariff { get; set; }
    }
}
