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
    public class InputSaveService : IInputSaveService
    {
        public async Task CreateAsyncInput(MartianRobotsInputDTO input)
        {
            string ApiURL = "https://localhost:44348/api/MartianRobotsInput/";

            HttpClient httpClient = new HttpClient();

            await httpClient.PostAsJsonAsync<MartianRobotsInputDTO>(ApiURL, input);
        }
    }
}
