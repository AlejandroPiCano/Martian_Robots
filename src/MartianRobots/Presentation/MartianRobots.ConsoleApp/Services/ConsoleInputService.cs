using MartianRobots.Application.DTOs;
using MartianRobots.ConsoleApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.ConsoleApp.Services
{
    internal class ConsoleInputService : IInputService
    {
        public MartianRobotsInputDTO GetInput()
        {
            MartianRobotsInputDTO input = new();

            Console.WriteLine("Please enter the size of X");
            input.XSize = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the size of Y");
            input.YSize = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the count of robots");
            int count = int.Parse(Console.ReadLine());

            input.Robots = new List<MartianRobotDTO>();

            for (int i = 0; i < count; i++)
            {
                var robot = new MartianRobotDTO();

                Console.WriteLine("Please enter the initial X for the robot");
                robot.InitialX = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter the initial Y for the robot");
                robot.InitialY = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter the initial orientation for the robot");
                robot.Orientation = Console.ReadLine().FirstOrDefault();

                Console.WriteLine("Please enter the instructions separated one by one without spaces");
                robot.Instructions = Console.ReadLine();

                input.Robots.Add(robot);
            }

            return input;
        }
    }
}
