using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DikuSharp.Mud.Logic
{
    public static class PlayerCharacterLogic
    { 
        /// <summary>
        /// Determine whether a given player name is valid.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static bool IsValidPlayerName( string line )
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
