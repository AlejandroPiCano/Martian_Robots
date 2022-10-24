using MartianRobots.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.Application.Commands
{
    public class DefaultCommandInstruction : CommandInstruction
    {
        public override void Execute(MartianRobotDTO robot)
        {            
        }

        public override void UndoExecute(MartianRobotDTO robot)
        {
        }
    }
}
