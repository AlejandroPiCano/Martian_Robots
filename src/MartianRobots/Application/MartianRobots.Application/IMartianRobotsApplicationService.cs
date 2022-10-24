using MartianRobots.Application.DTOs;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MartianRobots.Application
{
    public interface IMartianRobotsApplicationService
    {
        /// <summary>
        /// Create a input
        /// </summary>
        /// <param name="input"></param>
        List<MartianRobotsOutputDTO> Solve(MartianRobotsInputDTO input);        
    }
}