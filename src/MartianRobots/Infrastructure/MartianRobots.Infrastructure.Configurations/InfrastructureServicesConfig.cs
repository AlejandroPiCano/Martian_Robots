

using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Repository.Contracts;
using MartianRobots.Domain.Services;
using MartianRobots.Domain.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace MartianRobots.Infrastructure.Configurations
{
    /// <summary>
    /// AutoMapperConfig class.
    /// </summary>
    public static class InfrastructureServicesConfig
    {
        /// <summary>
        /// AddInfrastructureServicesConfiguration method.
        /// </summary>
        /// <param name="services"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddInfrastructureServicesConfiguration(this IServiceCollection services)
        {
            if (services == null) 
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<IMartianRobotsDomainService, MartianRobotsDomainService>();
            services.AddScoped<IRepository<MartianRobotsInput>, MartianRobotInputMongoDBRepository>();
            services.AddScoped<IRepository<MartianRobotsOutput>, MartianRobotOutputMongoDBRepository>();
        }
    }
}