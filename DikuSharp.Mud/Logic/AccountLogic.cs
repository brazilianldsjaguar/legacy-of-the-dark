using DikuSharp.Common;
using DikuSharp.Common.Characters;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DikuSharp.Mud.Logic
{
    public static class AccountLogic
    {
        public static PlayerCharacter FindCharacter( Account account, Predicate<PlayerCharacter> match )
        {
            return ((List<PlayerCharacter>)account.Characters).Find( match );
        }

        public static bool CharacterExists( Account account, string characterName )
        {
            return ( ((List<PlayerCharacter>)account.Characters).FindAll( c => c.Name.ToLower( ) == characterName.ToLower( ) ).Count > 0 );
        }

        public static bool IsValidAccountName( string line )
        {
            bool result = true;

            Regex regex = new Regex( "[A-Za-z]$" );
            if ( !regex.IsMatch( line ) )
            {
                result = false;
            }

            if ( line.Length > 15 )
            {
                result = false;
            }

            if ( line.Length < 4 )
            {
                result = false;
            }

            return result;
        }
    }
}
