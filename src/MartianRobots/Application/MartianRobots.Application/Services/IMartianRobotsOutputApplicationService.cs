using MartianRobots.Application.DTOs;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MartianRobots.Application.Services
{
    public interface IMartianRobotsOutputApplicationService
    {
        /// <summary>
        /// Create a output
        /// </summary>
        /// <param name="input"></param>
        Task<ValidationResult> CreateAsync(MartianRobotsOutputDTO input);

        /// <summary>
        /// Get an output item by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MartianRobotsOutputDTO> GetOutputAsync(int id);

        /// <summary>
        /// Get all outputs
        /// </summary>
        /// <returns></returns>
        Task<List<MartianRobotsOutputDTO>> GetAllOutputsAsync();
    }
}