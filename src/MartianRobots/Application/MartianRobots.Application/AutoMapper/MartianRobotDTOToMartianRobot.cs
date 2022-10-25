using AutoMapper;
using MartianRobots.Application.DTOs;
using MartianRobots.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.Application.AutoMapper
{
    /// <summary>
    /// The MartianRobotsInputDTOToEntity profile.
    /// </summary>
    public class MartianRobotDTOToMartianRobot : Profile
    {
        /// <summary>
        /// The UpdateInventoryCommandToInventoryItem constructor.
        /// </summary>
        public MartianRobotDTOToMartianRobot()
        {
            CreateMap<MartianRobotDTO, MartianRobot>();
        }
    }
}
