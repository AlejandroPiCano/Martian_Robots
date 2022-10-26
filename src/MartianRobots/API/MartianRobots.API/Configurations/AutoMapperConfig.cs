
using MartianRobots.Application.AutoMapper;
using MartianRobots.Application.DTOs;

namespace MartianRobots.API.Configurations
{
    /// <summary>
    /// AutoMapperConfig class.
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// AddAutoMapperConfiguration method.
        /// </summary>
        /// <param name="services"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) 
                throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(
                typeof(MartianRobotDTOToMartianRobot),
                typeof(MartianRobotToMartianRobotDTO),
                typeof(MartianRobotsInputDTOToMartianRobotsInput),
                typeof(MartianRobotsInputToMartianRobotsInputDTO),
                typeof(MartianRobotsInputDTOToMartianRobotsInput),
                typeof(MartianRobotsOutputDTOToMartianRobotsOutput),
                typeof(MartianRobotsOutputToMartianRobotsOutputDTO)
                );
        }
    }
}