namespace TeslaAPI.Models.Response
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// The ListResponse class.
    /// </summary>
    /// <typeparam name="T">The type of data in the <see cref="ListResponse{T}"/>.</typeparam>
    internal class ListResponse<T>
    {
        [JsonProperty("response")]
        public List<T> Data { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
