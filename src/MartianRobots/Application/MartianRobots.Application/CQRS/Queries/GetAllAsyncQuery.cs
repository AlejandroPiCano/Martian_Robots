using AutoMapper;
using MartianRobots.Application.DTOs;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Repository.Contracts;
using MediatR;
using System.Runtime.Serialization;

namespace MartianRobots.Application.Query
{
    public class GetAllAsyncQuery: IRequest<List<MartianRobotsInputDTO>>
    { 
        public class GetAllAsyncQueryHandler : IRequestHandler<GetAllAsyncQuery, List<MartianRobotsInputDTO>>
        {
            IRepository<MartianRobotsInput> repository;
            IMapper mapper;

            /// <summary>
            /// CreateInventoryCommandHandler constructor.
            /// </summary>
            /// <param name="repository"></param>
            public GetAllAsyncQueryHandler(IRepository<MartianRobotsInput> repository, IMapper mapper)
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
            public async Task<List<MartianRobotsInputDTO>> Handle(GetAllAsyncQuery request, CancellationToken cancellationToken)
            {
                var result = await repository.GetAllAsync();

                return result.Select(i => mapper.Map<MartianRobotsInputDTO>(i)).ToList();
            }
        }
    }
}