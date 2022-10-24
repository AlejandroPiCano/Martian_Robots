using MartianRobots.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.Application.Commands
{
    public class ForwardCommandInstruction : CommandInstruction
    {
        public override void Execute(MartianRobotDTO robot)
        {
            switch (robot.Orientation)
            {
                case 'N':
                    robot.InitialY++;

                    break;
                case 'S':
                    robot.InitialY--;

                    break;
                case 'E':
                    robot.InitialX++;

                    break;
                default:
                    robot.InitialX--;

                    break;
            }
        }

        public override void UndoExecute(MartianRobotDTO robot)
        {
            switch (robot.Orientation)
            {
                case 'N':
                    robot.InitialY--;

                    break;
                case 'S':
                    robot.InitialY++;

                    break;
                case 'E':
                    robot.InitialX--;

                    break;
                default:
                    robot.InitialX++;

                    break;
            }
        }


    }
}
