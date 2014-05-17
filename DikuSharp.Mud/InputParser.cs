using DikuSharp.Common;
using DikuSharp.Common.Commands;
using DikuSharp.Common.Characters;
using DikuSharp.Common.Extensions;
using DikuSharp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DikuSharp.Common.Areas;
using DikuSharp.Mud.Logic;

namespace DikuSharp.Mud
{
    public static class InputParser
    {
        /// <summary>
        /// The main entrance for input parsing
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="line"></param>
        public static void ParseInput( PlayerConnection connection, string line )
        {
            switch ( connection.CurrentConnectionState )
            {
                case ConnectionState.Connected: //They're just connected
                    ParseConnected( connection, line );
                    break;
                case ConnectionState.CreateAccount: //They've entered an account name that doesn't exist
                    ParseCreateAccount( connection, line );
                    break;
                case ConnectionState.Password:
                    ParsePassword( connection, line );
                    break;
                case ConnectionState.CreatePassword:
                case ConnectionState.CreatePasswordConfirm:
                    ParseCreatePassword( connection, line );
                    break;
                case ConnectionState.LoggedIn: //They've successfully logged in
                    ParseLoggedIn( connection, line );
                    break;
                case ConnectionState.CharacterCreationName:
                    ParseCharacterCreationName( connection, line );
                    break;
                case ConnectionState.CharacterCreationRace: //They've chosen to create a new character, this is the chargen
                    ParseCharacterCreationRace( connection, line );
                    break;
                case ConnectionState.CharacterCreationClass:
                    ParseCharacterCreationClass( connection, line );
                    break;
                case ConnectionState.CharacterCreationAncestry:
                    ParseCharacterCreationAncestry(connection, line);
                    break;
                case ConnectionState.Playing: //They're in the game
                    ParseCommand( connection, line );
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Parse account name and see if it exists or not.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="line"></param>
        private static void ParseConnected( PlayerConnection connection, string line )
        {
            //check if the name they entered is even valid
            if ( !AccountLogic.IsValidAccountName( line ) )
            {
                connection.Send( "That's not a valid name for an account!" );
                connection.Send( "Account names should be from 4-15 characters long and contain only letters." );
                connection.Send( "Please enter another account name:" );
            }
            else
            {
                if ( Game.AccountExists( line ) )
                {
                    connection.Account = Game.GetAccount( line );
                    //The account is there, we need the password
                    connection.Send( "What's your password?" );
                    connection.CurrentConnectionState = ConnectionState.Password;
                }
                else
                {
                    //they need to create an account!
                    connection.Send( "That account doesn't exist! Do you want to create a new one? Y/N" );
                    //Even though we don't know if they want to create an account at this point, we need to save the name
                    if ( connection.Account == null )
                    {
                        connection.Account = AccountData.InitializeAccount( line.ToTitleCase( ) );
                    }
                    connection.CurrentConnectionState = ConnectionState.CreateAccount;
                }
            }

        }

        /// <summary>
        /// Parse the response from an existing account's password
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="line"></param>
        private static void ParsePassword( PlayerConnection connection, string line )
        {
            //what the password should be:
            string pass = connection.Account.Password;

            //hash the line they put in
            string hashedLine = HashPassword( line );

            //Are the two the same?
            if ( pass == hashedLine )
            {
                //They are, log in!
                connection.Send( CharacterGeneration.GetAccountScreen( connection ) );
                connection.CurrentConnectionState = ConnectionState.LoggedIn;
            }
            else
            {
                connection.Send( "Wrong password." );
                connection.CurrentConnectionState = ConnectionState.Password;
            }
        }

        /// <summary>
        /// Parses the y/n response to whether or not a new account should be created.
        /// </summary>
        /// <param name="connection">The <see cref="PlayerConnection"/>.</param>
        /// <param name="line">The input.</param>
        private static void ParseCreateAccount( PlayerConnection connection, string line )
        {
            if ( line.ToLower( ) == "n" )
            {
                //They don't want to create an account, send them back to login
                connection.Send( "Okay, so what's your name?" );
                connection.CurrentConnectionState = ConnectionState.Connected;
            }
            else if ( line.ToLower( ) == "y" )
            {
                connection.Send( "Okay, what's your password?" );
                connection.CurrentConnectionState = ConnectionState.CreatePassword;
            }
            else
            {
                connection.Send( "That's no an option. Choose Y or N." );
                connection.CurrentConnectionState = ConnectionState.CreateAccount;
            }
        }

        /// <summary>
        /// Parses input from a new password, as well as confirming that password.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="line"></param>
        private static void ParseCreatePassword( PlayerConnection connection, string line )
        {
            if ( !IsValidPassword( line ) )
            {
                connection.Send( "Your password needs to be at least 8 characters." );
                connection.Send( "Please enter a new password:" );
            }
            else
            {
                string hashedPassword = HashPassword( line );

                switch ( connection.CurrentConnectionState )
                {
                    case ConnectionState.CreatePassword:
                        connection.Account.Password = hashedPassword;
                        connection.Send( "Type in your password again to confirm, please:" );
                        connection.CurrentConnectionState = ConnectionState.CreatePasswordConfirm;
                        break;
                    case ConnectionState.CreatePasswordConfirm:
                        if ( hashedPassword != connection.Account.Password )
                        {
                            connection.Send( "The passwords don't match. Please type in a new password:" );
                            connection.CurrentConnectionState = ConnectionState.CreatePassword;
                        }
                        else
                        {
                            //They've done it right twice, log them in and add their account to the list
                            Game.Accounts.Add( connection.Account );
                            //Save their account
                            AccountData.SaveAccount( connection.Account );
                            connection.Send( CharacterGeneration.GetAccountScreen( connection ) );
                            connection.CurrentConnectionState = ConnectionState.LoggedIn;
                        }
                        break;
                }
            }            
        }

        /// <summary>
        /// Parses input from account screen. Either new or a character.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="line"></param>
        private static void ParseLoggedIn( PlayerConnection connection, string line )
        {
            //At this point we know they're logged into their account - so let's make sure the reference properties are populated!
            connection.Account.CurrentConnection = connection;

            if ( line == "new" )
            {
                //new character!
                //connection.Account.CurrentCharacter = CharacterFactory.CreatePlayerCharacter( connection.Account, string.Empty );
                connection.Send( "Enter a name for your character:" );
                connection.CurrentConnectionState = ConnectionState.CharacterCreationName;
            }
            else
            {
                if ( AccountLogic.CharacterExists( connection.Account, line ) )
                {
                    Character pc = AccountLogic.FindCharacter( connection.Account, c => c.Name.ToLower( ) == line.ToLower( ) );
                    connection.Account.CurrentCharacter = pc;                    
                    //just in case ...
                    if ( pc.CurrentRoom == null )
                    {
                        RoomLogic.MoveCharacterToRoom( pc, null, Game.GetRoomById( int.Parse( ServerConfiguration.ReadAppConfig( "StartingRoom" ) ) ) );
                    }
                    //else
                    //{
                    //    RoomLogic.MoveCharacterToRoom( pc, null, pc.CurrentRoom );
                    //}
                    connection.Send( RoomLogic.GetRoomInformation( pc.CurrentRoom, pc ) );
                    connection.CurrentConnectionState = ConnectionState.Playing;                    
                }
                else
                {
                    if ( Game.PlayerCharacterExists( line ) )
                    {
                        connection.Send( "You don't own that character." );
                    }
                    else
                    {
                        connection.Send( "That character doesn't exist." );
                    }
                    connection.Send( "Please choose a character or type \"new\" to create a new one." );
                    connection.CurrentConnectionState = ConnectionState.LoggedIn;
                }
            }

        }

        /// <summary>
        /// Parses name selection in chargen.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="line"></param>
        private static void ParseCharacterCreationName( PlayerConnection connection, string line )
        {
            if ( !PlayerCharacterLogic.IsValidPlayerName( line ) )
            {
                connection.Send( "That's not a valid player name." );
                connection.Send( "Player names should be between 4-15 characters and have only letters." );
            }
            else
            {
                if ( Game.PlayerCharacterExists( line ) )
                {
                    connection.Send( "That character already exists." );
                    connection.Send( "Please enter a different name:" );
                }
                else
                {
                    Character pc = AccountData.CreatePlayerCharacter( connection.Account, line.ToTitleCase( ) );
                    // CharacterFactory.CreatePlayerCharacter( connection.Account, line.ToTitleCase( ) );
                    //Put them in the starting room
                    RoomLogic.MoveCharacterToRoom( pc, null, Game.GetRoomById( int.Parse( ServerConfiguration.ReadAppConfig( "StartingRoom" ) ) ) );                    
                    //connection.Account.Characters.Add( pc );
                    connection.Account.CurrentCharacter = pc;
                    connection.Send( CharacterGeneration.GetNewCharacterRaceScreen( Game.Races ) );
                    connection.CurrentConnectionState = ConnectionState.CharacterCreationRace;
                }
            }            
        }

        /// <summary>
        /// Parses input from race selection in chargen.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="line"></param>
        private static void ParseCharacterCreationRace( PlayerConnection connection, string line )
        {
            //check to see if the race even is an option
            if ( !Game.RaceExists( line ) )
            {
                connection.Send( "That's not a valid race option." );
                connection.Send( CharacterGeneration.GetNewCharacterRaceScreen( Game.Races ) );
            }
            else
            {
                connection.Account.CurrentCharacter.Race = Game.GetRace( line );
                connection.Send( CharacterGeneration.GetNewCharacterClassScreen( Game.Classes ) );
                connection.CurrentConnectionState = ConnectionState.CharacterCreationClass;
            }
        }

        /// <summary>
        /// Parses input from ancestry selection in chargen.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="line"></param>
        private static void ParseCharacterCreationAncestry(PlayerConnection connection, string line)
        {
            //check to see if the Ancestry even is an option
            if (!Game.AncestryExists(line))
            {
                connection.Send("That's not a valid ancestry option.");
                connection.Send(CharacterGeneration.GetNewCharacterAncestryScreen(Game.Ancestries));
            }
            else
            {
                connection.Account.CurrentCharacter.Ancestry = Game.GetAncestry(line);
                connection.Send(CharacterGeneration.GetNewCharacterAncestryScreen(Game.Ancestries));
                connection.CurrentConnectionState = ConnectionState.CharacterCreationAncestry;
            }
        }

        /// <summary>
        /// Parses input from the choice of classes in chargen.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="line"></param>
        private static void ParseCharacterCreationClass( PlayerConnection connection, string line )
        {
            //check to see if the race even is an option
            if ( !Game.ClassExists( line ) )
            {
                connection.Send( "That's not a valid class option." );
                connection.Send( CharacterGeneration.GetNewCharacterClassScreen( Game.Classes ) );
            }
            else
            {
                connection.Account.CurrentCharacter.Class = Game.GetClass( line );
                connection.Send( RoomLogic.GetRoomInformation( connection.CurrentRoom, connection.Account.CurrentCharacter ) );
                connection.CurrentConnectionState = ConnectionState.Playing;
            }

        }

        /// <summary>
        /// Specialized parsing for commands - usually input once you're playing, not while connecting
        /// </summary>
        /// <param name="account"></param>
        /// <param name="line"></param>
        public static void ParseCommand( PlayerConnection connection, string line )
        {
            if ( string.IsNullOrWhiteSpace( line ) )
                return;

            var args = GetArgsFromInput( line, new char[ ] { ' ' } );
            
            bool commandFound = false;

            foreach ( ICommand command in Game.Commands )
            {
                Type commandType = command.GetType( );
                if ( commandType.Name.ToLower( ).StartsWith( args[0].ToLower( ) ) )
                {
                    try
                    {
                        ICommand c = (ICommand)Activator.CreateInstance( commandType );
                        c.Do( connection.CurrentCharacter, args.Skip( 1 ).ToList( ) );
                        commandFound = true;
                    }
                    catch( Exception ex )
                    {
                        Console.WriteLine( "ERROR :: Could not interpret command." );
                        Console.WriteLine( ex.Message );
                        commandFound = false;
                    }
                    break;
                }
            }

            if ( !commandFound )
            {
                connection.Send( "Huh?" );
            }
        }

        /// <summary>
        /// Parse arguments from command input.
        /// </summary>
        /// <param name="stringToSplit"></param>
        /// <param name="delimiters"></param>
        /// <returns></returns>
        private static List<string> GetArgsFromInput( string stringToSplit, params char[ ] delimiters )
        {
            /*
             * Parse '' quotes (i.e. cast 'magic missile' <person>) - used for multi-word arguments
             *
             * This was adapted from Richard Shepherd's version found here:
             * http://stackoverflow.com/questions/554013/regular-expression-to-split-on-spaces-unless-in-quotes
             */
            List<string> results = new List<string>( );

            bool inQuote = false;
            StringBuilder currentToken = new StringBuilder( );
            for ( int index = 0 ; index < stringToSplit.Length ; ++index )
            {
                char currentCharacter = stringToSplit[ index ];
                if ( currentCharacter == '\'' )
                {
                    // When we see a ", we need to decide whether we are
                    // at the start or send of a quoted section...
                    inQuote = !inQuote;
                }
                else if ( delimiters.Contains( currentCharacter ) && inQuote == false )
                {
                    // We've come to the end of a token, so we find the token,
                    // trim it and add it to the collection of results...
                    string result = currentToken.ToString( ).Trim( );
                    if ( result != "" ) results.Add( result );

                    // We start a new token...
                    currentToken = new StringBuilder( );
                }
                else
                {
                    // We've got a 'normal' character, so we add it to
                    // the curent token...
                    currentToken.Append( currentCharacter );
                }
            }

            // We've come to the end of the string, so we add the last token...
            string lastResult = currentToken.ToString( ).Trim( );
            if ( lastResult != "" ) results.Add( lastResult );

            return results;
        }

        /// <summary>
        /// Hash a particular line with SHA256 (for passwords)
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static string HashPassword( string line )
        {
            HashAlgorithm algorithm = SHA256Managed.Create( );
            byte[ ] hash = algorithm.ComputeHash( Encoding.ASCII.GetBytes( line ) );
            StringBuilder hashedLine = new StringBuilder( );
            foreach ( byte b in hash )
            {
                hashedLine.Append( b.ToString( "X2" ) );
            }
            return hashedLine.ToString( );
        }

        /// <summary>
        /// Test whether or not a password meets the requirements.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static bool IsValidPassword( string password )
        {
            bool result = true;

            if ( password.Length < 8 )
            {
                result = false;
            }

            return result;
        }
    }
}
