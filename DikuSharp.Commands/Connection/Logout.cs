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
            if ( source is Character )
            {
                Character ch = source as Character;
                PlayerController pc = (PlayerController)ch.Controller;

                //Send a message to the room they're in
                pc.Send("You leave the game and are being directed to the login screen.");
                ch.SendToRoom( "{0} leaves the game.", ch.Name );

                //Send them back to the account screen
                pc.Send(CharacterGeneration.GetAccountScreen(pc.Account.CurrentConnection));
                pc.Account.CurrentConnection.CurrentConnectionState = ConnectionState.LoggedIn;
            }
        }
    }
}