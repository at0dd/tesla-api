namespace TeslaAPI.Models.Users
{
    using Newtonsoft.Json;

    public class VaultProfile
    {
        [JsonProperty("vault")]
        public string Vault { get; set; }
    }
}
