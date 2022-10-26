using MartianRobots.Application.DTOs;
using MartianRobots.Application.Services;
using MartianRobots.ConsoleApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.ConsoleApp.Services
{
    public class ApplicationLibrarySolveService : ISolveService
    {
        public Task<List<MartianRobotsOutputDTO>> Solve(MartianRobotsInputDTO input)
        {
            MartianRobotsApplicationService martianRobotsApplicationService = new MartianRobotsApplicationService();

            return Task.Run(() => martianRobotsApplicationService.Solve(input));
        }
    }
}
