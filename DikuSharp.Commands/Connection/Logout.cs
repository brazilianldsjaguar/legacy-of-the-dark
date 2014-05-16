using DikuSharp.Common;
using DikuSharp.Common.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Commands.Connection
{
    public class Logout : CommandBase
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
            if ( source is PlayerCharacter )
            {
                PlayerCharacter ch = source as PlayerCharacter;

                //Send a message to the room they're in
                ch.Send( "You leave the game and are being directed to the login screen." );
                ch.SendToRoom( "{0} leaves the game.", ch.Name );

                //Send them back to the account screen
                ch.Send( CharacterGeneration.GetAccountScreen( ch.Account.CurrentConnection ) );
                ch.Account.CurrentConnection.CurrentConnectionState = ConnectionState.LoggedIn;
            }
        }
    }
}