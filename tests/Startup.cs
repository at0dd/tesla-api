namespace Tests
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TeslaAPI;
    using Tests.Models;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", false, false)
                    .AddJsonFile("appsettings.Development.json", true, false)
                    .Build();

            services.Configure<TeslaConfiguration>(configuration.GetSection(TeslaConfiguration.SectionName));

            services.AddTeslaApi();
        }
    }
}
