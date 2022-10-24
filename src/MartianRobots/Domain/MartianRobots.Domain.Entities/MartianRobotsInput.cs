using System.Runtime.Serialization;

namespace MartianRobots.Domain.Entities
{
    public class MartianRobotsInput
    {
        public int X { get; set; }

        public int Y { get; set; }

        public List<MartianRobot> Robots { get; set; }
    }
}