namespace TeslaAPI.Models.Response
{
    using Newtonsoft.Json;

    /// <summary>
    /// The Response class.
    /// </summary>
    /// <typeparam name="T">The type of data in the <see cref="Response{T}"/>.</typeparam>
    internal class Response<T>
    {
        /// <summary>
        /// Gets or sets the response data.
        /// </summary>
        [JsonProperty("response")]
        public T Data { get; set; }
    }
}
