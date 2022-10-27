using MartianRobots.Domain.Entities;

namespace MartianRobots.Domain.CommandInstructions
{
    public class RightCommandInstruction : CommandInstruction
    {
        public override void Execute(MartianRobot robot)
        {
            robot.Orientation = ChangeOrientation(robot.Orientation, "r");
        }

        public override void UndoExecute(MartianRobot robot)
        {
            robot.Orientation = ChangeOrientation(robot.Orientation, "l");
        }
    }
}
