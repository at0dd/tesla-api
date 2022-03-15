namespace TeslaAPI.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// The Vehicle class.
    /// </summary>
    public class Vehicle
    {
        [JsonProperty("id")]
        public long ID { get; set; }

        [JsonProperty("user_id")]
        public long UserID { get; set; }

        [JsonProperty("vehicle_id")]
        public long VehicleID { get; set; }

        [JsonProperty("vin")]
        public string VIN { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("option_codes")]
        public string OptionCodes { get; set; }

        [JsonProperty("color")]
        public string? Color { get; set; }

        [JsonProperty("access_type")]
        public string AccessType { get; set; }

        [JsonProperty("tokens")]
        public List<string> Tokens { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("in_service")]
        public bool InService { get; set; }

        [JsonProperty("id_s")]
        public string IDS { get; set; }

        [JsonProperty("calendar_enabled")]
        public bool CalendarEnabled { get; set; }

        [JsonProperty("api_version")]
        public int APIVersion { get; set; }

        [JsonProperty("backseat_token")]
        public string? BackseatToken { get; set; }

        [JsonProperty("backseat_token_updated_at")]
        public DateTime? BackseatTokenUpdatedAt { get; set; }
    }
}
