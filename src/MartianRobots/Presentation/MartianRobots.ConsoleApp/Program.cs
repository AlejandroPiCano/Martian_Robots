using MartianRobots.Application;
using MartianRobots.Application.DTOs;
using Microsoft.Extensions.DependencyInjection;

namespace MartianRobots.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddScoped<IMartianRobotsApplicationService, MartianRobotsApplicationService>()
            .BuildServiceProvider();

            //do the actual work here
            MartianRobotsInputDTO input = GetInput();
            var martianRobotsService = serviceProvider.GetService<IMartianRobotsApplicationService>();

            var result = martianRobotsService.Solve(input);

            foreach (var output in result)
            {
                Console.WriteLine(output);
            }

            Console.ReadLine();
        }

        private static MartianRobotsInputDTO GetInput()
        {
            MartianRobotsInputDTO input = new ();

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