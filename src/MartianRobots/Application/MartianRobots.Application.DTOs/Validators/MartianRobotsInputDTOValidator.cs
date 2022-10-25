using FluentValidation;
using System.Runtime.Serialization;

namespace MartianRobots.Application.DTOs.Validators
{
    /// <summary>
    /// The InventoryItemDTO Validator.
    /// </summary>
    public class MartianRobotsInputDTOValidator : AbstractValidator<MartianRobotsInputDTO>
    {
        /// <summary>
        /// The MartianRobotsInputDTOValidator constructor.
        /// </summary>
        public MartianRobotsInputDTOValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.XSize).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.YSize).NotNull().GreaterThanOrEqualTo(0);
            RuleForEach(x => x.Robots).SetValidator(new MartianRobotDTOValidator());
        }
    }
}