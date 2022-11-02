using MartianRobots.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.ConsoleApp.Services.Contracts
{
    internal interface IInputService
    {
        MartianRobotsInputDTO GetInput();
    }
}
