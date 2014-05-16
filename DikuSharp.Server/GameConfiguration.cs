using System;
using System.Configuration;
using System.IO;
using System.Net;

namespace DikuSharp.Server
{
    public class GameConfiguration
    {
        public static IPAddress GetGameIPAddress( bool useAny = false )
        {
            if ( useAny )
            {
                return IPAddress.Any;
            }
            else { 
            return ( null == IPAddress.Parse( ConfigurationManager.AppSettings[ "GameIPAddress" ] ) ) ? IPAddress.Any :
                IPAddress.Parse( ConfigurationManager.AppSettings[ "GameIPAddress" ] );
            }
        }

        public static int GetGamePort( )
        {
            int ip = 4000;

            Int32.TryParse( ConfigurationManager.AppSettings[ "GamePort" ], out ip );

            return ip;
        }

        private static string ReadWelcomeMessageFromFile( )
        {
            string filePath = string.Empty;
            string message = string.Empty;

            if ( !string.IsNullOrEmpty( ConfigurationManager.AppSettings[ "WelcomeMessageFilePath" ] ) )
            {
                filePath = ConfigurationManager.AppSettings[ "WelcomeMessageFilePath" ];
                try
                {
                    using ( StreamReader sr = new StreamReader( File.Open( filePath, FileMode.OpenOrCreate ) ) )
                    {
                        message = sr.ReadToEnd( );
                    }
                }
                catch ( DirectoryNotFoundException )
                {
                    Console.WriteLine( "A welcome message file path is set, but is not readable. Switching to default message." );
                    message = String.Empty;
                }
            }

            return message;
        }

        public static string GetWelcomeMessage( )
        {
            string filePath = string.Empty;
            string message = string.Empty;

            //Attempt to read the message from a configured file
            message = ReadWelcomeMessageFromFile( );

            //if that didn't work, set it here
            if ( message == String.Empty )
            {
                message = "Welcome to the MUD!\n";
                message += "What's your account name?";
            }            

            return message;
        }
    }
}
