namespace TeslaAPI.Models.Engery
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Seasons
    {
        [JsonProperty("Summer")]
        public Season Summer { get; set; }

        [JsonProperty("Winter")]
        public Season Winter { get; set; }
    }

    public class Season
    {
        [JsonProperty("fromDay")]
        public int FromDay { get; set; }

        [JsonProperty("toDay")]
        public int ToDay { get; set; }

        [JsonProperty("fromMonth")]
        public int FromMonth { get; set; }

        [JsonProperty("toMonth")]
        public int ToMonth { get; set; }

        [JsonProperty("tou_periods")]
        public TOUPeriods TOUPeriouds { get; set; }
    }

    public class TOUPeriods
    {
        [JsonProperty("ON_PEAK")]
        public List<TOUPeriod> OnPeak { get; set; } = new List<TOUPeriod>();

        [JsonProperty("PARTIAL_PEAK")]
        public List<TOUPeriod> PartialPeak { get; set; } = new List<TOUPeriod>();

        [JsonProperty("OFF_PEAK")]
        public List<TOUPeriod> OffPeak { get; set; } = new List<TOUPeriod>();
    }

    public class TOUPeriod
    {
        [JsonProperty("fromDayOfWeek")]
        public int FromDayOfWeek { get; set; }

        [JsonProperty("toDayOfWeek")]
        public int ToDayOfWeek { get; set; }

        [JsonProperty("fromHour")]
        public int FromHour { get; set; }

        [JsonProperty("fromMinute")]
        public int FromMinute { get; set; }

        [JsonProperty("toHour")]
        public int ToHour { get; set; }

        [JsonProperty("toMinute")]
        public int ToMinute { get; set; }
    }
}
