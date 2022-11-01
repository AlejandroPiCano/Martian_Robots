
using MartianRobots.Application.AutoMapper;
using MartianRobots.Application.DTOs;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MartianRobots.Application.Configurations
{
    /// <summary>
    /// AutoMapperConfig class.
    /// </summary>
    public static class MediatRConfig
    {
        /// <summary>
        /// AddAutoMapperConfiguration method.
        /// </summary>
        /// <param name="services"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddMediatRConfiguration(this IServiceCollection services, Assembly[]? assemblies)
        {
            if (services == null) 
                throw new ArgumentNullException(nameof(services));

            services.AddMediatR(assemblies);
        }
    }
}