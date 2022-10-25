﻿using MartianRobots.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.Application.CommandInstructions
{
    public class LeftCommandInstruction : CommandInstruction
    {
        public override void Execute(MartianRobotDTO robot)
        {
            robot.Orientation = ChangeOrientation(robot.Orientation, "l");
        }

        public override void UndoExecute(MartianRobotDTO robot)
        {
            robot.Orientation = ChangeOrientation(robot.Orientation, "r");
        }
    }
}