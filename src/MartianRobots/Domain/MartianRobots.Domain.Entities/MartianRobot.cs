using System.Runtime.Serialization;

namespace MartianRobots.Domain.Entities
{
    public class MartianRobot
    {
        public int InitialX { get; set; }

        public int InitialY { get; set; }

        public char Orientation { get; set; }

        public string Instructions { get; set; }
    }
}