using AutoMapper;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Repository.Contracts;
using MediatR;
using System.Runtime.Serialization;

namespace MartianRobots.Application.DTOs
{
    public class CreateAsyncCommand: IRequest<int>
    {      
        public MartianRobotsInputDTO Input { get; set; }

        public CreateAsyncCommand(MartianRobotsInputDTO Input)
        {
            this.Input = Input;
        }

        public class CreateInventoryCommandHandler : IRequestHandler<CreateAsyncCommand, int>
        {
            IRepository<MartianRobotsInput> repository;
            IMapper mapper;

            /// <summary>
            /// CreateInventoryCommandHandler constructor.
            /// </summary>
            /// <param name="repository"></param>
            public CreateInventoryCommandHandler(IRepository<MartianRobotsInput> repository, IMapper mapper)
            {
                this.repository = repository;
                this.mapper = mapper;
            }

            /// <summary>
            /// The Handle method.
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<int> Handle(CreateAsyncCommand request, CancellationToken cancellationToken)
            {
                await repository.CreateAsync(mapper.Map<MartianRobotsInput>(request.Input));

                return 0;
            }
        }
    }
}