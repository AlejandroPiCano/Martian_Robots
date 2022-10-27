

using MartianRobots.Domain.CommandInstructions;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Services.Contracts;

namespace MartianRobots.Domain.Services
{
    public class MartianRobotsDomainService : IMartianRobotsDomainService
    {
        public List<MartianRobotsOutput> Solve(MartianRobotsInput input)
        {
            try
            {
                List<MartianRobotsOutput> result = new();

                foreach (var robot in input.Robots)
                {
                    MartianRobotsOutput output = new();

                    foreach (var instruction in robot.Instructions.ToLower())
                    {
                        var command = CommandInstructionFactory.GetCommand(instruction);
                        command.Execute(robot);

                        if (IsOutOfTheLimits(robot, input.XSize, input.YSize))
                        {
                            output.IsLost = true;
                            command.UndoExecute(robot);

                            break;
                        }
                    }

                    //output.Id = Guid.NewGuid();
                    output.Orientation = robot.Orientation;
                    output.FinalX = robot.InitialX;
                    output.FinalY = robot.InitialY;
                    result.Add(output);
                }

                return result;
            }
            catch (Exception)
            {
                return new List<MartianRobotsOutput>();
            }
        }

        /// <summary>
        /// Get if the robot is out of the limits.
        /// </summary>
        /// <param name="robot"></param>
        /// <param name="sizeX"></param>
        /// <param name="sizeY"></param>
        /// <returns>True if the robot is out of the limits, false if not </returns>
        private bool IsOutOfTheLimits(MartianRobot robot, int sizeX, int sizeY)
        {
            return robot.InitialX > sizeX || robot.InitialX < 0 || robot.InitialY > sizeY || robot.InitialY < 0;
        }
    }
}