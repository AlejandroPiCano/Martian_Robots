using MartianRobots.Domain.Entities;

namespace MartianRobots.Domain.CommandInstructions
{
    public class LeftCommandInstruction : CommandInstruction
    {
        public override void Execute(MartianRobot robot)
        {
            robot.Orientation = ChangeOrientation(robot.Orientation, "l");
        }

        public override void UndoExecute(MartianRobot robot)
        {
            robot.Orientation = ChangeOrientation(robot.Orientation, "r");
        }
    }
}
