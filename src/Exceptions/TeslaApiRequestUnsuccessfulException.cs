namespace TeslaAPI.Exceptions
{
    using System;

    /// <summary>
    /// Represents when an API request to the Tesla API resulted in an unsuccessful response.
    /// </summary>
    public sealed class TeslaApiRequestUnsuccessfulException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeslaApiRequestUnsuccessfulException"/> class.
        /// </summary>
        /// <param name="message">The message containing more information about why the API request was unsuccessful.</param>
        public TeslaApiRequestUnsuccessfulException(string message)
            : base(message)
        {
        }
    }
}
