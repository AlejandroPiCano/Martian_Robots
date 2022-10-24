using System.Runtime.Serialization;

namespace MartianRobots.Application.DTOs
{
    [DataContract]
    public class MartianRobotDTO
    {
        [DataMember]
        public int InitialX { get; set; }

        [DataMember]
        public int InitialY { get; set; }

        [DataMember]
        public char Orientation { get; set; }

        [DataMember]
        public string Instructions { get; set; }

    }
}