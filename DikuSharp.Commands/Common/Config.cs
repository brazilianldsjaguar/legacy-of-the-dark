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
            if ( source is Character )
            {
                Character ch = source as Character;

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

        private void SendConfigOptions( Character ch )
        {
            PlayerController pc = (PlayerController)ch.Controller;
            StringBuilder sb = new StringBuilder( );

            sb.AppendLine( "-------------------------------------------------" );
            sb.AppendLine( string.Format( "{0,-20} {1,-30}", ( pc.ConfigColor ) ? "#CCOLOR#x" : "#RCOLOR#x", "You " + ( ( pc.ConfigColor ) ? "#Cdo#x" : "#Rdon't#x" ) + " see colors." ) );
            sb.AppendLine( string.Format( "{0,-20} {1,-30}", ( pc.ConfigColor ) ? "#CCHAT#x" : "#RCHAT#x", "You " + ( ( pc.ConfigColor ) ? "#Cdo#x" : "#Rdon't#x" ) + " see the CHAT channel." ) );
            sb.AppendLine( "-------------------------------------------------" );
            sb.AppendLine( "Syntax: config <option>" );

            pc.Send( sb.ToString( ) );
        }

        private void ToggleConfigColor( Character ch )
        {
            PlayerController pc = (PlayerController)ch.Controller;
            pc.ConfigColor = !pc.ConfigColor;
            string message = ( pc.ConfigColor ) ? "#Con#x" : "off";
            pc.Send( "ANSI Color has been turned {0}.", message );
        }
    }
}
