using MartianRobots.Application.DTOs;
using MartianRobots.Application.DTOs.Validators;
using MartianRobots.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace MartianRobots.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            MartianRobotsInputDTO input = GetInputFromJsonFile();
            List<MartianRobotsOutputDTO> result = new List<MartianRobotsOutputDTO>();

            #region Library call
            //TODO: Uncomment this for use the Application libraries
            //var serviceProvider = new ServiceCollection()
            //.AddScoped<IMartianRobotsApplicationService, MartianRobotsApplicationService>()
            //.BuildServiceProvider();

            ////do the actual work here
            //var martianRobotsService = serviceProvider.GetService<IMartianRobotsApplicationService>();

            //result = martianRobotsService.Solve(input);

            #endregion

            #region API call
            string ApiURL = "https://localhost:44348/api/MartianRobots/";

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsJsonAsync<MartianRobotsInputDTO>(ApiURL, input);                       

            if (response.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<MartianRobotsOutputDTO>>(stringContent);
            }

            #endregion

            PrintOutput(result);
            
            Console.ReadLine();
        }

        private static void PrintOutput(List<MartianRobotsOutputDTO> result)
        {
            foreach (var output in result)
            {
                Console.WriteLine(output);
            }
        }

        private static MartianRobotsInputDTO GetInputFromConsole()
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

        private static MartianRobotsInputDTO GetInputFromJsonFile()
        {
            try
            {
                using (StreamReader r = new StreamReader("../../../input.json"))
                {
                    string json = r.ReadToEnd();

                    return JsonConvert.DeserializeObject<MartianRobotsInputDTO>(json);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("An error has ocurred in the Json file, you can enter the input by console");

               return GetInputFromConsole();
            }           
        }
    }
}