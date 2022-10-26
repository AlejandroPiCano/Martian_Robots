using FluentValidation;
using System.Runtime.Serialization;

namespace MartianRobots.Application.DTOs.Validators
{
    /// <summary>
    /// The InventoryItemDTO Validator.
    /// </summary>
    public class MartianRobotsOutputDTOValidator : AbstractValidator<MartianRobotsOutputDTO>
    {
        /// <summary>
        /// The MartianRobotsInputDTOValidator constructor.
        /// </summary>
        public MartianRobotsOutputDTOValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.FinalX).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.FinalY).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.Orientation).NotNull().Must((x, orientation) => orientation == 'n' || orientation == 'N' || orientation == 's' || orientation == 'S'
           || orientation == 'e' || orientation == 'E' || orientation == 'w' || orientation == 'W');
        }
    }
}