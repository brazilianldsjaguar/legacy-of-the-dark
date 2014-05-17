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
            if ( source is Character )
            {
                Character ch = source as Character;
                PlayerController pc = (PlayerController)ch.Controller;
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
                    pc.Send("Syntax: areas [list/create]");
                }
                    
                
            }
        }

        private void CreateArea( Character ch, List<string> args )
        {
            PlayerController pc = (PlayerController)ch.Controller;
            //This is a sub-command, so we start with args[1]
            if ( args.Count < 2 )
            {
                pc.Send( "Syntax: areas create <area name>" );
                return;
            }

            string areaName = args[ 1 ];

            if ( Game.AreaExists( areaName ) )
            {
                pc.Send( "That area already exists! Choose a different name." );
                return;
            }

            Game.Areas.Add( new Area( ) { Name = areaName, Author = pc.Account.AccountName } );
            //Attempt to save areas
            pc.Send( areaName + " area created. Attempting to save ..." );
            try
            {
                AreaData.SaveAreas( Game.Areas );
            }
            catch ( Exception e )
            {
                pc.Send( "There was a problem. Check out this message:" );
                pc.Send( e.Message );
            }
        }

        private void SendAreaList( Character ch )
        {
            PlayerController pc = (PlayerController)ch.Controller;
            pc.Send( "{0,-15} {1,-10}", "Area Name", "Author" );
            foreach ( Area a in Game.Areas )
            {
                pc.Send( "{0,-15} {1,-10}", a.Name, a.Author );
            }
        }
    }
}
