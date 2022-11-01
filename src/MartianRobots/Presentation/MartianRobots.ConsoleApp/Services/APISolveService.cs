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
    public class APISolveService : ISolveService
    {
        public async Task<List<MartianRobotsOutputDTO>> Solve(MartianRobotsInputDTO input)
        {
            string ApiURL = "https://localhost:44348/api/MartianRobots/";

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsJsonAsync<MartianRobotsInputDTO>(ApiURL, input);

            if (response.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<MartianRobotsOutputDTO>>(stringContent);
            }

            return new List<MartianRobotsOutputDTO>();
        }
    }
}
