using MartianRobots.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.Domain.CommandInstructions
{
    /// <summary>
    /// The command instruction
    /// </summary>
    public abstract class CommandInstruction
    {
       public abstract void Execute(MartianRobot robot);

       public abstract void UndoExecute(MartianRobot robot);

        internal char ChangeOrientation(char orientation, string nextRotation)
        {
            switch (orientation)
            {
                case 'N':
                    orientation = nextRotation == "l" ? 'W' : 'E';

                    break;
                case 'S':
                    orientation = nextRotation == "l" ? 'E' : 'W';

                    break;
                case 'W':
                    orientation = nextRotation == "l" ? 'S' : 'N';

                    break;
                default: //East
                    orientation = nextRotation == "l" ? 'N' : 'S';

                    break;
            }

            return orientation;
        }
    }
}
