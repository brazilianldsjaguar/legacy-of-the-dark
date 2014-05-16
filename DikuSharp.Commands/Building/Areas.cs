using DikuSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DikuSharp.Mud;
using DikuSharp.Data;
using DikuSharp.Common.Areas;
using DikuSharp.Common.Characters;

namespace DikuSharp.Commands.Building
{
    public class Areas : CommandBase
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
                        case "list":
                            SendAreaList( ch );
                            break;
                        case "create":
                            CreateArea( ch, args );
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
                    ch.Send( "Syntax: areas [list/create]" );
                }
                    
                
            }
        }

        private void CreateArea( PlayerCharacter ch, List<string> args )
        {
            //This is a sub-command, so we start with args[1]
            if ( args.Count < 2 )
            {
                ch.Send( "Syntax: areas create <area name>" );
                return;
            }

            string areaName = args[ 1 ];

            if ( Game.AreaExists( areaName ) )
            {
                ch.Send( "That area already exists! Choose a different name." );
                return;
            }

            Game.Areas.Add( new Area( ) { Name = areaName, Author = ch.Account.AccountName } );
            //Attempt to save areas
            ch.Send( areaName + " area created. Attempting to save ..." );
            try
            {
                AreaData.SaveAreas( Game.Areas );
            }
            catch ( Exception e )
            {
                ch.Send( "There was a problem. Check out this message:" );
                ch.Send( e.Message );
            }
        }

        private void SendAreaList( PlayerCharacter ch )
        {
            ch.Send( "{0,-15} {1,-10}", "Area Name", "Author" );
            foreach ( Area a in Game.Areas )
            {
                ch.Send( "{0,-15} {1,-10}", a.Name, a.Author );
            }
        }
    }
}
