using MartianRobots.Application.DTOs;
using MartianRobots.ConsoleApp.Services.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MartianRobots.ConsoleApp.Services
{
    internal class APISolveService : APIService, ISolveService
    {    
        public async Task<List<MartianRobotsOutputDTO>> Solve(MartianRobotsInputDTO input)
        {
            string ApiURL = $"https://localhost:{apiPort}/api/MartianRobots/";           

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var content = new StringContent(JsonConvert.SerializeObject(input), Encoding.Default, "application/json"))
                {
                    HttpRequestMessage httpRequestMessage = GetHttpRequestMessage(content, ApiURL);

                    var response = await httpClient.SendAsync(httpRequestMessage);

                    if (response.IsSuccessStatusCode)
                    {
                        var stringContent = await response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<List<MartianRobotsOutputDTO>>(stringContent);
                    }

                    return new List<MartianRobotsOutputDTO>();
                }
            }
        }
    }
}
