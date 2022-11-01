
using FluentValidation;
using MartianRobots.Application.AutoMapper;
using MartianRobots.Application.DTOs;
using MartianRobots.Application.DTOs.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace MartianRobots.Application.Configurations
{
    /// <summary>
    /// AutoMapperConfig class.
    /// </summary>
    public static class FluentValidationConfig
    {
        /// <summary>
        /// AddAutoMapperConfiguration method.
        /// </summary>
        /// <param name="services"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            if (services == null) 
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<IValidator<MartianRobotDTO>, MartianRobotDTOValidator>();
            services.AddScoped<IValidator<MartianRobotsInputDTO>, MartianRobotsInputDTOValidator>();
            services.AddScoped<IValidator<MartianRobotsOutputDTO>, MartianRobotsOutputDTOValidator>();
        }
    }
}