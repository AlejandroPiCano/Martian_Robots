using FluentValidation.Results;
using MartianRobots.Application.DTOs;
using MartianRobots.Application.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MartianRobots.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MartianRobotsOutputController : ControllerBase
    {
        private IMartianRobotsOutputApplicationService service;
        private ILogger<MartianRobotsOutputController> logger;

        public MartianRobotsOutputController(IMartianRobotsOutputApplicationService service, ILogger<MartianRobotsOutputController> logger) 
        {
            this.service = service;
            this.logger = logger;
        }

        // GET: api/<MartianRobotsOutputController>
        [HttpGet]
        public async Task<List<MartianRobotsOutputDTO>> Get()
        {
            List<MartianRobotsOutputDTO> result = null;

            try
            {
                return await service.GetAllOutputsAsync();
            }
            catch (System.Exception e)
            {
                logger.LogInformation(e.Message);
            }

            return result;
        }

        // GET api/<MartianRobotsOutputController>/231a3358-12a6-4216-801f-c1fb84882aa9
        [HttpGet("{id}")]
        public async Task<MartianRobotsOutputDTO> Get(Guid id)
        {
            MartianRobotsOutputDTO result = null;

            try
            {
                return await service.GetOutputAsync(id);
            }
            catch (System.Exception e)
            {
                logger.LogInformation(e.Message);
            }

            return result;
        }

        // POST api/<MartianRobotsOutputController>
        [HttpPost]
        public async Task<ValidationResult> Post([FromBody] MartianRobotsOutputDTO value)
        {
            try
            {
                return await service.CreateAsync(value);
            }
            catch (System.Exception e)
            {
                logger.LogInformation(e.Message);

                return await Task.Run(() =>
                {
                    var result = new ValidationResult();
                    result.Errors.Add(new ValidationFailure(String.Empty, e.Message));

                    return result;
                });
            }
        }      
    }
}
