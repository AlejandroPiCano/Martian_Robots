using MartianRobots.Application.DTOs;
using MartianRobots.ConsoleApp.Services.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.ConsoleApp.Services
{
    internal class InputSaveService : APIService, IInputSaveService
    {
        public async Task CreateAsyncInput(MartianRobotsInputDTO input)
        {
            string ApiURL = $"https://localhost:{apiPort}/api/MartianRobotsInput/";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var content = new StringContent(JsonConvert.SerializeObject(input), Encoding.Default, "application/json"))
                {
                    HttpRequestMessage httpRequestMessage = GetHttpRequestMessage(content, ApiURL);                    

                    await httpClient.SendAsync(httpRequestMessage);
                }
            }
        }
    }
}
