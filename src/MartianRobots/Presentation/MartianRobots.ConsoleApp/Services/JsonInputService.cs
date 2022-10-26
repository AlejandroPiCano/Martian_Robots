using MartianRobots.Application.DTOs;
using MartianRobots.ConsoleApp.Services.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.ConsoleApp.Services
{
    public class JsonInputService : IInputService
    {
        public MartianRobotsInputDTO GetInput()
        {
            try
            {
                using (StreamReader r = new StreamReader("../../../input.json"))
                {
                    string json = r.ReadToEnd();

                    return JsonConvert.DeserializeObject<MartianRobotsInputDTO>(json);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
