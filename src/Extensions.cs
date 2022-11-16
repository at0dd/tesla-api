namespace TeslaAPI
{
    using System.Globalization;
    using System.Net.Http;
    using System.Threading.Tasks;
    using global::TeslaAPI.Models;
    using global::TeslaAPI.Models.Response;

    /// <summary>
    /// The Extensions class.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Navigate to a destination.
        /// </summary>
        /// <param name="instance">TeslaAPI instance.</param>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="latitude">Destination latitude.</param>
        /// <param name="longitude">Destination longitude.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public static Task<CommandResponse> ShareAsync(this ITeslaAPI instance, HttpClient client, string vehicleID, float latitude, float longitude)
        {
            return instance.ShareAsync(client, vehicleID, string.Format(CultureInfo.InvariantCulture, "{0},{1}", latitude, longitude), "en-US");
        }
    }
}
