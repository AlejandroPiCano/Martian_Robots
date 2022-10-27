

using MartianRobots.Domain.Entities;

namespace MartianRobots.Domain.CommandInstructions
{
    public class ForwardCommandInstruction : CommandInstruction
    {
        public override void Execute(MartianRobot robot)
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

        public override void UndoExecute(MartianRobot robot)
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
