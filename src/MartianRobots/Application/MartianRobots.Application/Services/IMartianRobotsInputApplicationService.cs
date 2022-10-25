using MartianRobots.Application.DTOs;
using MartianRobots.Application.DTOs.Validators;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MartianRobots.Application.Services
{
    public interface IMartianRobotsInputApplicationService
    {
        /// <summary>
        /// Create a input
        /// </summary>
        /// <param name="input"></param>
        Task<ValidationResult> CreateAsync(MartianRobotsInputDTO input);

        /// <summary>
        /// Get input by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The input</returns>
        Task<MartianRobotsInputDTO> GetInputAsync(int id);

        /// <summary>
        /// Get all inputs
        /// </summary>
        /// <returns>The list of inputs</returns>
        Task<List<MartianRobotsInputDTO>> GetAllInputsAsync();
    }
}