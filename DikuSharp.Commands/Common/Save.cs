using DikuSharp.Common;
using DikuSharp.Common.Characters;
using DikuSharp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Commands.Common
{
    public class Save : CommandBase
    {
        public override int Priority
        {
            get
            {
                return 1;
            }
        }

        public override void Do( object source, List<string> args )
        {
            if ( source is DikuSharp.Common.Characters.PlayerCharacter )
            {
                DikuSharp.Common.Characters.PlayerCharacter ch = source as DikuSharp.Common.Characters.PlayerCharacter;
                AccountData.SaveAccount( ch.Account );
                ch.Send( "Saved." );
            }
        }
    }
}
