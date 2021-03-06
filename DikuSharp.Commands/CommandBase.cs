﻿using DikuSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DikuSharp.Common.Characters;
using DikuSharp.Common.Commands;

namespace DikuSharp.Commands
{
    public abstract class CommandBase : ICommand
    {
        public virtual int Priority { get { return 10; } }

        public virtual void Do( object source, List<string> args ) 
        {
            if ( source is Character )
            {
                Character ch = source as Character;
                PlayerController pc = (PlayerController)ch.Controller;
                pc.Send( "Huh?" );
            }
        }
    }
}
