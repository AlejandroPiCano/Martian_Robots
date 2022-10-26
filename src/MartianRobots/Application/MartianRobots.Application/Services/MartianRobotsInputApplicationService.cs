using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MartianRobots.Application.DTOs;
using MartianRobots.Application.DTOs.Validators;
using MartianRobots.Application.Query;
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
        IValidator<MartianRobotsInputDTO> validator;
        IMediator mediator;

        public MartianRobotsInputApplicationService(IValidator<MartianRobotsInputDTO> validator, IMediator mediator)
        {
            this.validator = validator;
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

        public async Task<List<MartianRobotsInputDTO>> GetAllInputsAsync()
        {
           return await mediator.Send(new GetAllAsyncQuery());
        }

        public async Task<MartianRobotsInputDTO> GetInputAsync(Guid id)
        {
            return await mediator.Send(new GetAsyncQuery(id));
        }
    }
}
