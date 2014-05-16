using DikuSharp.Common.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Commands.Common
{
    public class Config : CommandBase
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
                bool argFound = true;

                if ( args.Count > 0 )
                {
                    switch ( args[ 0 ] )
                    {
                        case "color":
                            ToggleConfigColor( ch );
                            break;
                        default:
                            argFound = false;
                            break;
                    }
                }
                else
                {
                    argFound = false;
                }

                if ( !argFound )
                {
                    SendConfigOptions( ch );
                }
            }
        }

        private void SendConfigOptions( PlayerCharacter ch )
        {
            StringBuilder sb = new StringBuilder( );

            sb.AppendLine( "-------------------------------------------------" );
            sb.AppendLine( string.Format( "{0,-20} {1,-30}", ( ch.ConfigColor ) ? "#CCOLOR#x" : "#RCOLOR#x", "You " + ( ( ch.ConfigColor ) ? "#Cdo#x" : "#Rdon't#x" ) + " see colors." ) );
            sb.AppendLine( string.Format( "{0,-20} {1,-30}", ( ch.ConfigColor ) ? "#CCHAT#x" : "#RCHAT#x", "You " + ( ( ch.ConfigColor ) ? "#Cdo#x" : "#Rdon't#x" ) + " see the CHAT channel." ) );
            sb.AppendLine( "-------------------------------------------------" );
            sb.AppendLine( "Syntax: config <option>" );

            ch.Send( sb.ToString( ) );
        }

        private void ToggleConfigColor( PlayerCharacter ch )
        {
            ch.ConfigColor = !ch.ConfigColor;
            string message = ( ch.ConfigColor ) ? "#Con#x" : "off";
            ch.Send( "ANSI Color has been turned {0}.", message );
        }
    }
}
