namespace TeslaAPI.Models.Engery
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ProgramsResponse
    {
        [JsonProperty("programs")]
        public List<string> Programs { get; set; } = new List<string>();
    }
}
