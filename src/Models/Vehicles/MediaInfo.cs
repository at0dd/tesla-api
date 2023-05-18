namespace TeslaAPI.Models.Vehicles
{
    using Newtonsoft.Json;

    public class MediaInfo
    {
        [JsonProperty("audio_volume")]
        public double AudioVolume { get; set; }

        [JsonProperty("audio_volume_increment")]
        public double AudioVolumeIncrement { get; set; }

        [JsonProperty("audio_volume_max")]
        public double AudioVolumeMaximum { get; set; }

        [JsonProperty("media_playback_status")]
        public string MediaPlaybackStatus { get; set; }

        [JsonProperty("now_playing_album")]
        public string NowPlayingAlbum { get; set; }

        [JsonProperty("now_playing_artist")]
        public string NowPlayingArtist { get; set; }

        [JsonProperty("now_playing_duration")]
        public double NowPlayingDuration { get; set; }

        [JsonProperty("now_playing_elapsed")]
        public double NowPlayingElapsed { get; set; }

        [JsonProperty("now_playing_source")]
        public string NowPlayingSource { get; set; }

        [JsonProperty("now_playing_station")]
        public string NowPlayingStation { get; set; }

        [JsonProperty("now_playing_title")]
        public string NowPlayingTitle { get; set; }
    }
}
