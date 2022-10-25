using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MartianRobots.Application.DTOs.Validators
{
    public class MartianRobotDTOValidator : AbstractValidator<MartianRobotDTO>
    {
        /// <summary>
        /// The MartianRobotDTOValidator constructor.
        /// </summary>
        public MartianRobotDTOValidator()
        {
            RuleFor(x => x.InitialX).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.InitialY).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.Orientation).NotNull().Must((x, orientation) => orientation == 'n' || orientation == 'N' || orientation == 's' || orientation == 'S'
            || orientation == 'e' || orientation == 'E' || orientation == 'w' || orientation == 'W');
            RuleFor(x => x.Instructions).NotNull().Must((x, instruction) => Regex.Match(instruction, "^[lrfLRF]+$").Success);
        }
    }
}
