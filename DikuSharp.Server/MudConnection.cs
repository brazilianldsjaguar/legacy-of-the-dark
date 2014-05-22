using DikuSharp.Mud;
using DikuSharp.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DikuSharp.Server
{
    public class MudConnection
    {
        private PlayerConnection account;
        private TcpClient _client;

        public MudConnection( TcpClient client )
        {
            _client = client;
            account = new PlayerConnection( _client );
            new Thread( ClientLoop ).Start( );
        }

        void ClientLoop( )
        {
            try
            {
                Game.ConnectPlayer( account, GameConfiguration.GetWelcomeMessage( ) );

                while ( true )
                {
                    Game.FlushConnections( );

                    string line = account.Read( );
                    
                    if ( line == null )
                        break;

                    InputParser.ParseInput( account, line );
                }
            }
            finally
            {
                Game.DisconnectPlayer( account );
            }            
        }
    }
}
