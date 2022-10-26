using MartianRobots.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.ConsoleApp.Services.Contracts
{
    public interface IOutputService
    {
        void PrintOutput(List<MartianRobotsOutputDTO> outputs);
    }
}
