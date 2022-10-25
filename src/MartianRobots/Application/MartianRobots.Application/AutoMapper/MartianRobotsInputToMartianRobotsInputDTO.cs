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
    /// The MartianRobotsInputToDTO profile.
    /// </summary>
    public class MartianRobotsInputToMartianRobotsInputDTO : Profile
    {
        /// <summary>
        /// The UpdateInventoryCommandToInventoryItem constructor.
        /// </summary>
        public MartianRobotsInputToMartianRobotsInputDTO()
        {
            CreateMap<MartianRobotsInput, MartianRobotsInputDTO>();
        }
    }
}
