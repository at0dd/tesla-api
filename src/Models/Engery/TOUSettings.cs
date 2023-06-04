namespace TeslaAPI.Models.Engery
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class TOUSettings
    {
        [JsonProperty("optimization_strategy")]
        public string OptimizationStrategy { get; set; }

        [JsonProperty("schedule")]
        public List<TOUSchedule> Schedule { get; set; } = new List<TOUSchedule>();
    }
}
