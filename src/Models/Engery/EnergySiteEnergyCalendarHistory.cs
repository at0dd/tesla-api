namespace TeslaAPI.Models.Engery
{
    using Newtonsoft.Json;

    public class EnergySiteEnergyCalendarHistory : EnergySitePowerHistory
    {
        [JsonProperty("time_zone_offset")]
        public int TimeZoneOffset { get; set; }
    }
}
