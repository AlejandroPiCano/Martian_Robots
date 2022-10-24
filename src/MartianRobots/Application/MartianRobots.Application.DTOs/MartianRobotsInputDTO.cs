using System.Runtime.Serialization;

namespace MartianRobots.Application.DTOs
{
    [DataContract]
    public class MartianRobotsInputDTO
    {
        [DataMember]
        public int XSize { get; set; }

        [DataMember]
        public int YSize { get; set; }

        public List<MartianRobotDTO> Robots { get; set; }
    }
}