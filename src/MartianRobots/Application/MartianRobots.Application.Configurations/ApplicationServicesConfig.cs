
using Microsoft.Extensions.DependencyInjection;
using MartianRobots.Application.Services;

namespace MartianRobots.Application.Configurations
{
    /// <summary>
    /// AutoMapperConfig class.
    /// </summary>
    public static class ApplicationServicesConfig
    {
        /// <summary>
        /// AddInfrastructureServicesConfiguration method.
        /// </summary>
        /// <param name="services"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddApplicationServicesConfiguration(this IServiceCollection services)
        {
            if (services == null) 
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<IMartianRobotsInputApplicationService, MartianRobotsInputApplicationService>();
            services.AddScoped<IMartianRobotsOutputApplicationService, MartianRobotsOutputApplicationService>();
            services.AddScoped<IMartianRobotsApplicationService, MartianRobotsApplicationService>();
        }
    }
}