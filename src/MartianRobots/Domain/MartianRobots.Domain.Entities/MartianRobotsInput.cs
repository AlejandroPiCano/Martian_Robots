
namespace MartianRobots.Domain.Entities
{
    public class MartianRobotsInput
    {       
        public Guid Id { get; set; }

        public int XSize { get; set; }

        public int YSize { get; set; }

        public List<MartianRobot> Robots { get; set; }
    }
}