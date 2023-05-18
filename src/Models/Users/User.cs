namespace TeslaAPI.Models.Users
{
    using Newtonsoft.Json;

    public class User
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("profile_image_url")]
        public string ProfileImageURL { get; set; }
    }
}
