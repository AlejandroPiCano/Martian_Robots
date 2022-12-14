using System.Runtime.Serialization;

namespace MartianRobots.Domain.Entities
{
    public class MartianRobotsOutput
    {
        public Guid Id { get; set; }

        public int FinalX { get; set; }

        public int FinalY { get; set; }

        public char Orientation { get; set; }

        public bool IsLost { get; set; }
    }
}