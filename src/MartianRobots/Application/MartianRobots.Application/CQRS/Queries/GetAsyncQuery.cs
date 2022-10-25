using AutoMapper;
using MartianRobots.Application.DTOs;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Repository.Contracts;
using MediatR;
using System.Runtime.Serialization;

namespace MartianRobots.Application.Query
{
    public class GetAsyncQuery: IRequest<MartianRobotsInputDTO>
    {      
        public Guid Id { get; set; }

        public GetAsyncQuery(Guid Id)
        {
            this.Id = Id;
        }

        public class GetAsyncQueryHandler : IRequestHandler<GetAsyncQuery, MartianRobotsInputDTO>
        {
            IRepository<MartianRobotsInput> repository;
            IMapper mapper;

            /// <summary>
            /// CreateInventoryCommandHandler constructor.
            /// </summary>
            /// <param name="repository"></param>
            public GetAsyncQueryHandler(IRepository<MartianRobotsInput> repository, IMapper mapper)
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
            public async Task<MartianRobotsInputDTO> Handle(GetAsyncQuery request, CancellationToken cancellationToken)
            {
                var result = await repository.GetAsync(request.Id);

                return mapper.Map<MartianRobotsInputDTO>(result);
            }
        }
    }
}