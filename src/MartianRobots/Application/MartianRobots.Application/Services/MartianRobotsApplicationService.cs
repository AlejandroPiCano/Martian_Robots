using MartianRobots.Application.CommandInstructions;
using MartianRobots.Application.DTOs;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MartianRobots.Application.Services
{
    public class MartianRobotsApplicationService : IMartianRobotsApplicationService
    {
        public List<MartianRobotsOutputDTO> Solve(MartianRobotsInputDTO input)
        {
            try
            {
                List<MartianRobotsOutputDTO> result = new();

                foreach (var robot in input.Robots)
                {
                    MartianRobotsOutputDTO output = new();

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

                    output.Orientation = robot.Orientation;
                    output.FinalX = robot.InitialX;
                    output.FinalY = robot.InitialY;
                    result.Add(output);
                }

                return result;
            }
            catch (Exception)
            {
                return new List<MartianRobotsOutputDTO>();
            }
        }

        /// <summary>
        /// Get if the robot is out of the limits.
        /// </summary>
        /// <param name="robot"></param>
        /// <param name="sizeX"></param>
        /// <param name="sizeY"></param>
        /// <returns>True if the robot is out of the limits, false if not </returns>
        private bool IsOutOfTheLimits(MartianRobotDTO robot, int sizeX, int sizeY)
        {
            return robot.InitialX > sizeX || robot.InitialX < 0 || robot.InitialY > sizeY || robot.InitialY < 0;
        }
    }
}