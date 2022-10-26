using MartianRobots.Application.DTOs;
using MartianRobots.ConsoleApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.ConsoleApp.Services
{
    internal class OutputService : IOutputService
    {
        public void PrintOutput(List<MartianRobotsOutputDTO> outputs)
        {
            foreach (var output in outputs)
            {
                Console.WriteLine(output);
            }
        }
    }
}
