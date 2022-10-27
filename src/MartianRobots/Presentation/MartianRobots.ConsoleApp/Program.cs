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
                .AddScoped<ISolveService, APISolveService>()
                .AddScoped<IOutputSaveService, OutputSaveService>()
                .AddScoped<IInputSaveService, InputSaveService>()
                .BuildServiceProvider();

            var inputService = serviceProvider.GetService<IInputService>();
            var outputService = serviceProvider.GetService<IOutputService>();
            var solveService = serviceProvider.GetService<ISolveService>();
            var inputSaveService = serviceProvider.GetService<IInputSaveService>();
            var outputSaveService = serviceProvider.GetService<IOutputSaveService>();

            // Get the input
            MartianRobotsInputDTO input = inputService.GetInput();

            // Save the input
            inputSaveService.CreateAsyncInput(input);

            // Get the solution
            List<MartianRobotsOutputDTO> result = await solveService.Solve(input);

            // Save the output
            foreach (var output in result)
            {
                outputSaveService.CreateAsynOutput(output);
            }

            // Print the output.
            outputService.PrintOutput(result);
            
            Console.ReadLine();
        }              
    }
}