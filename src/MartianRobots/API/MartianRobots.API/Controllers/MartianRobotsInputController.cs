using FluentValidation.Results;
using MartianRobots.Application.DTOs;
using MartianRobots.Application.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MartianRobots.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MartianRobotsInputController : ControllerBase
    {
        private IMartianRobotsInputApplicationService service;
        private ILogger<MartianRobotsInputController> logger;

        public MartianRobotsInputController(IMartianRobotsInputApplicationService service, ILogger<MartianRobotsInputController> logger) 
        {
            this.service = service;
            this.logger = logger;
        }

        // GET: api/<MartianRobotsInputController>
        [HttpGet]
        public async Task<List<MartianRobotsInputDTO>> Get()
        {
            List<MartianRobotsInputDTO> result = null;

            try
            {
                return await service.GetAllInputsAsync();
            }
            catch (System.Exception e)
            {
                logger.LogInformation(e.Message);
            }

            return result;
        }

        // GET api/<MartianRobotsInputController>/231a3358-12a6-4216-801f-c1fb84882aa9
        [HttpGet("{id}")]
        public async Task<MartianRobotsInputDTO> Get(Guid id)
        {
            MartianRobotsInputDTO result = null;

            try
            {
                return await service.GetInputAsync(id);
            }
            catch (System.Exception e)
            {
                logger.LogInformation(e.Message);
            }

            return result;
        }

        // POST api/<MartianRobotsInputController>
        [HttpPost]
        public async Task<ValidationResult> Post([FromBody] MartianRobotsInputDTO value)
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
