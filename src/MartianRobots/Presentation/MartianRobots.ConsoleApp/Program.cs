using MartianRobots.Application.DTOs;
using MartianRobots.Application.DTOs.Validators;
using MartianRobots.Application.Services;
using MartianRobots.ConsoleApp.Services;
using MartianRobots.ConsoleApp.Services.Contracts;
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
            var serviceProvider = new ServiceCollection()
                .AddScoped<IInputService, JsonInputService>()// Or ConsoleInputService
                .AddScoped<IOutputService, OutputService>()
                .AddScoped<ISolveService, APISolveService>()// Or ApplicationLibrarySolveService
                .BuildServiceProvider();

            var inputService = serviceProvider.GetService<IInputService>();
            var outputService = serviceProvider.GetService<IOutputService>();
            var solveService = serviceProvider.GetService<ISolveService>();

            // Get the input
            MartianRobotsInputDTO input = inputService.GetInput();

            // Get the solution
            List<MartianRobotsOutputDTO> result = await solveService.Solve(input);

            // Print the output.
            outputService.PrintOutput(result);
            
            Console.ReadLine();
        }              
    }
}