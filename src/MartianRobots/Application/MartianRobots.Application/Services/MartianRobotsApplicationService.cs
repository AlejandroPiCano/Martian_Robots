using AutoMapper;
using MartianRobots.Application.DTOs;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Services.Contracts;

namespace MartianRobots.Application.Services
{
    public class MartianRobotsApplicationService : IMartianRobotsApplicationService
    {
        IMartianRobotsDomainService domainService;
        IMapper mapper;

        public MartianRobotsApplicationService(IMartianRobotsDomainService domainService, IMapper mapper)
        {
            this.domainService = domainService;
            this.mapper = mapper;
        }

        public List<MartianRobotsOutputDTO> Solve(MartianRobotsInputDTO input)
        {
            var result = domainService.Solve(mapper.Map<MartianRobotsInput>(input));

            return result.Select(o => mapper.Map<MartianRobotsOutputDTO>(o)).ToList();
        }
    }
}