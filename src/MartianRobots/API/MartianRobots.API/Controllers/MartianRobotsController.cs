using FluentValidation.Results;
using MartianRobots.Application.DTOs;
using MartianRobots.Application.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MartianRobots.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MartianRobotsController : ControllerBase
    {
        private IMartianRobotsApplicationService service;
        private ILogger<MartianRobotsController> logger;

        public MartianRobotsController(IMartianRobotsApplicationService service, ILogger<MartianRobotsController> logger) 
        {
            this.service = service;
            this.logger = logger;
        }              

        // POST api/<MartianRobotsInputController>
        [HttpPost]
        public List<MartianRobotsOutputDTO> Post([FromBody] MartianRobotsInputDTO value)
        {
            try
            {
                return service.Solve(value);
            }
            catch (System.Exception e)
            {
                logger.LogInformation(e.Message);

                return new List<MartianRobotsOutputDTO>();
            }
        }      
    }
}
