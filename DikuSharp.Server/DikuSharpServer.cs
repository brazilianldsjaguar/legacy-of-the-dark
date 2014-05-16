using System;
using System.Net.Sockets;

namespace DikuSharp.Server
{
    class DikuSharpServer
    {
        private static TcpListener listener;

        static void Main( string[ ] args )
        {
            listener = new TcpListener( GameConfiguration.GetGameIPAddress( useAny: true ), GameConfiguration.GetGamePort( ) );
            
            listener.Start( );

            while ( true )
            {
                Console.WriteLine( "Awaiting connection ... " );
                TcpClient client = listener.AcceptTcpClient( );
                Console.WriteLine( "Connection: {0}", client.Client.RemoteEndPoint.ToString( ) );

                new MudConnection( client );
            }
        }
    }
}
