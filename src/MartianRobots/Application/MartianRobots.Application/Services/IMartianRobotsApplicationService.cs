using MartianRobots.Application.DTOs;
using MartianRobots.Application.DTOs.Validators;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MartianRobots.Application.Services
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