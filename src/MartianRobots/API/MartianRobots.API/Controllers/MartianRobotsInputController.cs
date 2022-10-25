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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MartianRobotsInputController>/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            return "value";
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

        // PUT api/<MartianRobotsInputController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] string value)
        {
        }

        // DELETE api/<MartianRobotsInputController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
