using System;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;


namespace DikuSharp.Server
{
    public class DikuSharpServer
    {
        private static TcpListener listener;
        

        static void Main( string[ ] args )
        {
            listener = new TcpListener( GameConfiguration.GetGameIPAddress( useAny: true ), GameConfiguration.GetGamePort( ) );
            
            listener.Start( );
            Console.WriteLine("Generating basic map...");
            Common.Map newMap = new Common.Map();
            newMap = Mud.MapGen.BasicMapGeneration(Common.MapGenTypes.BasicGrass);
            Mud.Game.Maps[0] = newMap;
            Console.WriteLine("Starting main server tick...");
            maintick newMain = new maintick();
            Thread newThread = new Thread(new ThreadStart(newMain.mainTick));
            newThread.Start();
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
