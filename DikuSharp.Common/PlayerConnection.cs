using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using DikuSharp.Common.Characters;
using DikuSharp.Common.Items;
using DikuSharp.Common.Areas;

namespace DikuSharp.Common
{
    public class PlayerConnection
    {
        public TcpClient Client { get; set; }
        public ConnectionState CurrentConnectionState { get; set; }
        public Account Account { get; set; }
        public StreamReader Reader { get; set; }
        public StreamWriter Writer { get; set; }


        #region Shortcut properties

        public Character CurrentCharacter { 
            get { return Account.CurrentCharacter; }
            set { Account.CurrentCharacter = value; }
        }
        public Room CurrentRoom { 
            get { return Account.CurrentCharacter.CurrentRoom; }
            set { Account.CurrentCharacter.CurrentRoom = value; }   
        }
        public Race Race { 
            get { return Account.CurrentCharacter.Race; }
            set { Account.CurrentCharacter.Race = value; }
        }
        public Class Class { 
            get { return Account.CurrentCharacter.Class; }
            set { Account.CurrentCharacter.Class = value; }
        }

        #endregion

        public PlayerConnection( TcpClient client )
        {
            Client = client;
            var stream = client.GetStream( );
            Reader = new StreamReader( stream );
            Writer = new StreamWriter( stream );
            CurrentConnectionState = ConnectionState.Connected;
        }

        public string Read( )
        {
            return Reader.ReadLine( );
        }

        public void Send( string message )
        {
            //only colorize if they've got an active character
            if ( Account != null && Account.CurrentCharacter != null )
            {
                PlayerController controller = (PlayerController)CurrentCharacter.Controller;
                message = Colorizer.Colorize( message, controller.ConfigColor );
            }
            Writer.WriteLine( message );
        }

        public void Send( string formatMessage, params object[ ] args )
        {
            //format first
            string formattedMessage = string.Format( formatMessage, args );
            //Send it to the other "send" so it can be colored
            Send( formattedMessage );
        }

        public void Flush( )
        {
            Writer.Flush( );
        }

        public void Close( )
        {
            Reader.Close( );
            Writer.Close( );
            Client.Close( );
        }

    }
}
