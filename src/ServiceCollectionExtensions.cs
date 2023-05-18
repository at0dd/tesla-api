namespace TeslaAPI
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register all services for the Tesla API.
        /// </summary>
        /// <param name="services">The services of your application to register the Tesla API with.</param>
        /// <returns>The originating <see cref="IServiceCollection"/> with the Tesla API services registered.</returns>
        public static IServiceCollection AddTeslaApi(this IServiceCollection services)
        {
            services.AddScoped<ITeslaAPI, TeslaAPI>();

            return services;
        }
    }
}
