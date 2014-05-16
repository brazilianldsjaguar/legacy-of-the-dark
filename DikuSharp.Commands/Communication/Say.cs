using DikuSharp.Common.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Commands.Communication
{
    class Say : CommandBase
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
            if ( source is PlayerCharacter )
            {
                PlayerCharacter ch = source as PlayerCharacter;
                string statement = string.Join( " ", args.ToArray( ) );
                ch.Send( "You say, '#G{0}#x'", statement );
                ch.SendToRoom( "{0} says '#G{1}#x'", ch.Name, statement );
            }
        }
    }
}
