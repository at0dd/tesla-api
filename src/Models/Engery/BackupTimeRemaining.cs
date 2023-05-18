namespace TeslaAPI.Models.Engery
{
    using Newtonsoft.Json;

    public class BackupTimeRemaining
    {
        [JsonProperty("time_remaining_hours")]
        public double TimeRemainingHours { get; set; }
    }
}
