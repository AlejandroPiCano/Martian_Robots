using MartianRobots.Domain.Entities;

namespace MartianRobots.Domain.Services.Contracts
{
    public interface IMartianRobotsDomainService
    {        List<MartianRobotsOutput> Solve(MartianRobotsInput input);
    }
}