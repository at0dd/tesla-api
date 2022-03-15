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
        /// <summary>
        /// Gets or sets a list of response data.
        /// </summary>
        [JsonProperty("response")]
        public List<T> Data { get; set; }

        /// <summary>
        /// Gets or sets the number of items returned in the list.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
