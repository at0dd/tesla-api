namespace TeslaAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// The Vehicle class.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Gets or sets the identifier for the <see cref="Vehicle"/> for the Owner-API endpoints.
        /// </summary>
        [JsonPropertyName("id")]
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the <see cref="Vehicle"/> across all endpoints like the Autopark API.
        /// </summary>
        [JsonPropertyName("vehicle_id")]
        public long VehicleID { get; set; }

        /// <summary>
        /// Gets or sets the Vehicle Identification Number.
        /// </summary>
        [JsonPropertyName("vin")]
        public string VIN { get; set; }

        /// <summary>
        /// Gets or sets the name of the <see cref="Vehicle"/>.
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets a comma separated list of option codes for the <see cref="Vehicle"/>.
        /// </summary>
        [JsonPropertyName("option_codes")]
        public string OptionCodes { get; set; }

        /// <summary>
        /// Gets or sets the color of the <see cref="Vehicle"/>.
        /// </summary>
        [JsonPropertyName("color")]
        public string? Color { get; set; }

        /// <summary>
        /// Gets or sets a list of tokens for the <see cref="Vehicle"/>.
        /// </summary>
        [JsonPropertyName("tokens")]
        public List<string> Tokens { get; set; }

        /// <summary>
        /// Gets or sets the current state of the <see cref="Vehicle"/>.
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="Vehicle"/> is in service or not.
        /// </summary>
        [JsonPropertyName("in_service")]
        public bool InService { get; set; }

        /// <summary>
        /// Gets or sets the string version of the ID.
        /// </summary>
        [JsonPropertyName("id_s")]
        public string IDS { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether calendar sync is enabled.
        /// </summary>
        [JsonPropertyName("calendar_enabled")]
        public bool CalendarEnabled { get; set; }

        /// <summary>
        /// Gets or sets the API version.
        /// </summary>
        [JsonPropertyName("api_version")]
        public int APIVersion { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="BackseatToken"/> for the <see cref="Vehicle"/>.
        /// </summary>
        [JsonPropertyName("backseat_token")]
        public string? BackseatToken { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="BackseatTokenUpdatedAt"/> for the <see cref="Vehicle"/>.
        /// </summary>
        [JsonPropertyName("backseat_token_updated_at")]
        public DateTime? BackseatTokenUpdatedAt { get; set; }
    }
}
