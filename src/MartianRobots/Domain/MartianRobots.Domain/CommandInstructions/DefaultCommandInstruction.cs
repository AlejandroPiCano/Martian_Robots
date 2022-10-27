using MartianRobots.Domain.Entities;

namespace MartianRobots.Domain.CommandInstructions
{
    public class DefaultCommandInstruction : CommandInstruction
    {
        public override void Execute(MartianRobot robot)
        {            
        }

        public override void UndoExecute(MartianRobot robot)
        {
        }
    }
}
