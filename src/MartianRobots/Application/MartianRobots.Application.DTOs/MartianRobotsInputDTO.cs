using System.Runtime.Serialization;

namespace MartianRobots.Application.DTOs
{
    [DataContract]
    public class MartianRobotsInputDTO
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public int XSize { get; set; }

        [DataMember]
        public int YSize { get; set; }

        [DataMember]
        public List<MartianRobotDTO> Robots { get; set; }
    }
}