namespace TeslaAPI.Exceptions
{
    using System;
    using System.Net;

    /// <summary>
    /// Represents when an API request to the Tesla API resulted in an unsuccessful response.
    /// </summary>
    public sealed class TeslaApiRequestUnsuccessfulException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeslaApiRequestUnsuccessfulException"/> class.
        /// </summary>
        /// <param name="responseCode">The response code from the API.</param>
        /// <param name="message">The message containing more information about why the API request was unsuccessful.</param>
        public TeslaApiRequestUnsuccessfulException(HttpStatusCode responseCode, string message)
            : base(message)
        {
            ResponseCode = responseCode;
        }

        public HttpStatusCode ResponseCode { get; set; }
    }
}
