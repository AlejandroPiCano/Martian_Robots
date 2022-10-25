using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MartianRobots.Application.DTOs;
using MartianRobots.Application.DTOs.Validators;
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
    public class MartianRobotsInputApplicationService : IMartianRobotsInputApplicationService
    {
        IRepository<MartianRobotsInput> repository;
        IValidator<MartianRobotsInputDTO> validator;
        IMapper mapper;
        IMediator mediator;

        public MartianRobotsInputApplicationService(IRepository<MartianRobotsInput> repository, IValidator<MartianRobotsInputDTO> validator, IMapper mapper, IMediator mediator)
        {
            this.repository = repository;
            this.validator = validator;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<ValidationResult> CreateAsync(MartianRobotsInputDTO input)
        {
            ValidationResult result = validator.Validate(input);

            if (result.IsValid)
            {
                await  mediator.Send(new CreateAsyncCommand(input));
            }

            return result;
        }

        public Task<List<MartianRobotsInputDTO>> GetAllInputsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MartianRobotsInputDTO> GetInputAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
