﻿using DikuSharp.Common;
using DikuSharp.Common.Characters;
using DikuSharp.Mud.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Commands.Common
{
    public class Look : CommandBase
    {
        public override int Priority
        {
            get
            {
                return 1;
            }
        }

        public override void Do( object source, List<string> target )
        {
            if ( source is Character )
            {
                Character ch = source as Character;
                PlayerController pc = (PlayerController)ch.Controller;
                pc.Send(RoomLogic.GetRoomInformation(ch.CurrentRoom, looker: ch));
            }
        }
    }
}
