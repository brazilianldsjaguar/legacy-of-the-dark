using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DikuSharp.Common.Commands;
using DikuSharp.Common;
using DikuSharp.Common.Extensions;
using DikuSharp.Data;
using System.Reflection;
using System.Collections;
using DikuSharp.Common.Characters;
using DikuSharp.Common.Areas;

namespace DikuSharp.Mud
{
    public static class Game
    {
        public static List<PlayerConnection> PlayerConnections = new List<PlayerConnection>( );
        public static List<Account> Accounts = AccountData.LoadAccounts( );
        public static List<Area> Areas = AreaData.LoadAreas( );
        public static List<Room> Rooms = Game.GetRooms( );
        public static List<Class> Classes = ClassData.LoadClasses( );
        public static List<Race> Races = RaceData.LoadRaces( );
        public static List<Ancestry> Ancestries = AncestryData.LoadAncestries();
        public static List<Starsign> Starsigns = StarsignData.LoadStarsigns();
        public static List<Character> PlayerCharacters = Game.GetPlayerCharacters( );
        public static List<ICommand> Commands { get { return commands; } }
        private static List<ICommand> commands = Game.GetCommands( ).OrderBy( x => x.Priority ).ToList( );
        
        /// <summary>
        /// Get a collection of all the player characters under all the accounts. This is so we can check to make sure
        /// not only accounts aren't duplicated, but characters aren't either.
        /// </summary>
        /// <returns></returns>
        private static List<Character> GetPlayerCharacters( )
        {
            List<Character> players = new List<Character>( );
            if ( Game.Accounts != null )
            {
                foreach ( Account account in Game.Accounts )
                {
                    players.AddRange( account.Characters );
                }
            }
            return players;
        }

        /// <summary>
        /// Get a collection of all the rooms in all the areas. This is so we can check to make sure
        /// if a room exists or otherwise.
        /// </summary>
        /// <returns>A list of <see cref="Room"/>s.</returns>
        private static List<Room> GetRooms( )
        {
            List<Room> rooms = new List<Room>( );
            if ( Game.Areas != null )
            {
                foreach ( Area area in Game.Areas )
                {
                    rooms.AddRange( area.Rooms );
                }
            }
            return rooms;
        }

        /// <summary>
        /// Get a <see cref="Room"/> object based on its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Room GetRoomById( int id )
        {
            return Rooms.Find( r => r.ID == id );
        }

        /// <summary>
        /// Get a specific account from the list of accounts based on the account name
        /// </summary>
        /// <param name="accountName">A string representing the account name</param>
        /// <returns>An <see cref="Account"/> object of the account, if it exists.</returns>
        internal static Account GetAccount( string accountName )
        {
            return Accounts.Find( a => a.AccountName.ToLower( ) == accountName.ToLower( ) );
        }

        /// <summary>
        /// Get a specific race from the list of races, based on a racename string.
        /// </summary>
        /// <param name="raceName">A string representing the name of the race</param>
        /// <returns>A <see cref="Race"/> object</returns>
        internal static Race GetRace( string raceName )
        {
            return Races.Find( r => r.Name.ToLower( ) == raceName.ToLower( ) );
        }

        /// <summary>
        /// Get a specific ancestry from the list of ancestries, based on a ancestryname string.
        /// </summary>
        /// <param name="raceName">A string representing the name of the ancestry</param>
        /// <returns>A <see cref="Race"/> object</returns>
        internal static Ancestry GetAncestry(string ancestryName)
        {
            return Ancestries.Find(r => r.Name.ToLower() == ancestryName.ToLower());
        }

        /// <summary>
        /// Get a specific starsign from the list of starsigns, based on a starsignname string.
        /// </summary>
        /// <param name="raceName">A string representing the name of the starsign</param>
        /// <returns>A <see cref="Race"/> object</returns>
        internal static Starsign GetStarsign(string starsignName)
        {
            return Starsigns.Find(r => r.Name.ToLower() == starsignName.ToLower());
        }

        /// <summary>
        /// Get a specific class from the list of classes, based on a classname string.
        /// </summary>
        /// <param name="className">A string representing the name of the class</param>
        /// <returns>A <see cref="Class"/> object</returns>
        internal static Class GetClass( string className )
        {
            return Classes.Find( c => c.Name.ToLower( ) == className.ToLower( ) );
        }

        /// <summary>
        /// Checks to see if an account exists.
        /// </summary>
        /// <param name="accountName">A string of the account name. Case insensitive.</param>
        /// <returns>True if exists, false otherwise.</returns>
        internal static bool AccountExists( string accountName )
        {
            return ( Accounts.FindAll( a => a.AccountName.ToLower( ) == accountName.ToLower( ) ).Count > 0 );
        }

        /// <summary>
        /// Checks to see if a player character exists.
        /// </summary>
        /// <param name="characterName">A string of the character name. Case insensitive.</param>
        /// <returns>True if exists, false otherwise.</returns>
        internal static bool PlayerCharacterExists( string characterName )
        {
            return ( PlayerCharacters.FindAll( c => c.Name.ToLower( ) == characterName.ToLower( ) ).Count > 0 );
        }

        /// <summary>
        /// Checks to see if a race exists.
        /// </summary>
        /// <param name="raceName">A string of the name of the race. Case insensitive.</param>
        /// <returns>True if exists, false otherwise.</returns>
        internal static bool RaceExists( string raceName )
        {
            return ( Races.FindAll( r => r.Name.ToLower( ) == raceName.ToLower( ) ).Count > 0 );
        }

        /// <summary>
        /// Checks to see if a ancestry exists.
        /// </summary>
        /// <param name="raceName">A string of the name of the ancestry. Case insensitive.</param>
        /// <returns>True if exists, false otherwise.</returns>
        internal static bool AncestryExists(string ancestryName)
        {
            return (Ancestries.FindAll(r => r.Name.ToLower() == ancestryName.ToLower()).Count > 0);
        }

        /// <summary>
        /// Checks to see if a starsign exists.
        /// </summary>
        /// <param name="raceName">A string of the name of the starsign. Case insensitive.</param>
        /// <returns>True if exists, false otherwise.</returns>
        internal static bool StarsignExists(string starsignName)
        {
            return (Starsigns.FindAll(r => r.Name.ToLower() == starsignName.ToLower()).Count > 0);
        }

        /// <summary>
        /// Checks to see if a class exists.
        /// </summary>
        /// <param name="className">A string of the name of the class. Case insensitive.</param>
        /// <returns>True if exists, false otherwise.</returns>
        internal static bool ClassExists( string className )
        {
            return ( Classes.FindAll( c => c.Name.ToLower( ) == className.ToLower( ) ).Count > 0 );
        }

        /// <summary>
        /// Checks to see if an area exists.
        /// </summary>
        /// <param name="areaName">Name of the area. Case insensitive.</param>
        /// <returns>True if exists, false otherwise.</returns>
        public static bool AreaExists( string areaName )
        {
            return ( Areas.FindAll( a => a.Name.ToLower( ) == areaName.ToLower( ) ).Count > 0 );
        }

        /// <summary>
        /// Disconnect a player from the game.
        /// </summary>
        /// <param name="account">The connection to disconnect.</param>
        public static void DisconnectPlayer( PlayerConnection connection )
        {
            PlayerConnections.Remove( connection );
            connection.Close( );
        }

        /// <summary>
        /// Connect a player to the game.
        /// </summary>
        /// <param name="connection">The connection to add to the game.</param>
        /// <param name="connectMessage">The message to send the connection once added.</param>
        public static void ConnectPlayer( PlayerConnection connection, string connectMessage )
        {
            PlayerConnections.Add( connection );
            connection.Send( connectMessage );
        }

        public static void FlushConnections( )
        {
            foreach ( PlayerConnection conn in PlayerConnections )
            {
                conn.Flush( );
            }
        }

        /// <summary>
        /// Load the commands dynamically.
        /// </summary>
        /// <returns></returns>
        public static List<ICommand> GetCommands( )
        {
            List<ICommand> list = new List<ICommand>( );
            //We have to load the command assembly as it's not referenced directly
            //We had to do this so that DikuSharp.Commands could reference DikuSharp.Mud without a circular reference
            AppDomain.CurrentDomain.Load( "DikuSharp.Commands" );
            List<Assembly> commandAssembly2 = AppDomain.CurrentDomain.GetAssemblies( ).Select( s => s ).Where( x => x.GetName( ).Name == "DikuSharp.Commands" ).ToList( );
            Assembly commandAssembly = commandAssembly2[ 0 ];
            try
            {
                Type[ ] types = commandAssembly.GetTypes( );

                IEnumerator enumerator2 = types.GetEnumerator( );
                while ( enumerator2.MoveNext( ) )
                {
                    Type current = (Type)enumerator2.Current;
                    if ( typeof(ICommand).IsAssignableFrom( current ) && !current.IsAbstract )
                    {
                        list.Add( (ICommand)Activator.CreateInstance( current ));
                    }                   
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on GetCommands(" + e.Message + ")");
            }
            return list;
        }
    }
}
