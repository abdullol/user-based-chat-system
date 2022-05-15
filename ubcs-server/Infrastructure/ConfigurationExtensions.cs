using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ubcs_server.Infrastructure
{
    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnectionString(
            this IConfiguration configuration)
        => configuration.GetConnectionString("DefaultConnection");

        public static AppSettings GetApplicationSettings(this IServiceCollection services,
            IConfiguration configuration)
        {
            var applicationSettingsConfigurations = configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(applicationSettingsConfigurations);

            return applicationSettingsConfigurations.Get<AppSettings>();
        }

    }
}
