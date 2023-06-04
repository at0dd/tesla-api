namespace TeslaAPI.Models.Response
{
    using Newtonsoft.Json;

    /// <summary>
    /// The CommandResponse class.
    /// </summary>
    public class CommandResponse
    {
        /// <summary>
        /// Gets or sets an explaination for the response.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the result was successful.
        /// </summary>
        [JsonProperty("result")]
        public bool Result { get; set; }
    }

    public class ScheduleSoftwareUpdateResponse : CommandResponse
    {
        [JsonProperty("expected_duration_sec")]
        public long ExpectedDurationSeconds { get; set; }

        [JsonProperty("scheduled_time_ms")]
        public long ScheduledTimeMilliseconds { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("warning_time_remaining_ms")]
        public long WarningTimeRemainingMilliseconds { get; set; }
    }
}
