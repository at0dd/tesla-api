namespace TeslaAPI.Models.Engery
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class TOUSchedule
    {
        [JsonProperty("target")]
        public string Target { get; set; }

        [JsonProperty("week_days")]
        public List<int> WeekDays { get; set; }

        [JsonProperty("start_seconds")]
        public long StartSeconds { get; set; }

        [JsonProperty("end_seconds")]
        public long EndSeconds { get; set; }
    }
}
