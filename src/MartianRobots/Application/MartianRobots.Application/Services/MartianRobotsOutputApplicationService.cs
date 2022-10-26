using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MartianRobots.Application.DTOs;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Repository.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.Application.Services
{
    public class MartianRobotsOutputApplicationService : IMartianRobotsOutputApplicationService
    {
        IRepository<MartianRobotsOutput> repository;
        IValidator<MartianRobotsOutputDTO> validator;
        IMapper mapper;

        public MartianRobotsOutputApplicationService(IRepository<MartianRobotsOutput> repository, IValidator<MartianRobotsOutputDTO> validator, IMapper mapper)
        {
            this.repository = repository;
            this.validator = validator;
            this.mapper = mapper;
        }

        public async Task<ValidationResult> CreateAsync(MartianRobotsOutputDTO input)
        {
            ValidationResult result = validator.Validate(input);

            if (result.IsValid)
            {
                await repository.CreateAsync(mapper.Map<MartianRobotsOutput>(input));
            }

            return result;
        }

        public async Task<List<MartianRobotsOutputDTO>> GetAllOutputsAsync()
        {
            var result = await repository.GetAllAsync();

            return result.Select(o => mapper.Map<MartianRobotsOutputDTO>(o)).ToList();
        }

        public async Task<MartianRobotsOutputDTO> GetOutputAsync(Guid id)
        {
            var result = await repository.GetAsync(id);

            return mapper.Map<MartianRobotsOutputDTO>(result);
        }
    }
}
