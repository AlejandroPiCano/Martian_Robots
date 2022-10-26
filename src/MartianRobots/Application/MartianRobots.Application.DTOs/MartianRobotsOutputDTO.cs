using System.Runtime.Serialization;

namespace MartianRobots.Application.DTOs
{
    public class MartianRobotsOutputDTO
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public int FinalX { get; set; }

        [DataMember]
        public int FinalY { get; set; }

        [DataMember]
        public char Orientation { get; set; }

        public bool IsLost { get; set; }

        public override string ToString()
        {
            return $"{FinalX} {FinalY} {Orientation} {(IsLost ? "LOST": "")}";
        }
    }
}