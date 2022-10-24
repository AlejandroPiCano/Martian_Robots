using MartianRobots.Application.Commands;

namespace MartianRobots.Application
{
    internal class CommandInstructionFactory
    {
        internal static CommandInstruction GetCommand(char instruction)
        {
            switch (instruction)
            {
                case 'l':
                    return new LeftCommandInstruction();
                case 'r':
                    return new RightCommandInstruction();
                case 'f':
                    return new ForwardCommandInstruction();
                default:
                    return new DefaultCommandInstruction();
            }
        }
    }
}