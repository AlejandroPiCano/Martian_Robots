using MartianRobots.Application.DTOs;
using MartianRobots.ConsoleApp.Services.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.ConsoleApp.Services
{
    public class OutputSaveService : IOutputSaveService
    {
        public async Task CreateAsynOutput(MartianRobotsOutputDTO output)
        {
            string ApiURL = "https://localhost:7147/api/MartianRobotsOutput/";

            HttpClient httpClient = new HttpClient();

            await httpClient.PostAsJsonAsync<MartianRobotsOutputDTO>(ApiURL, output);
        }

    }
}
