using DikuSharp.Common;
using DikuSharp.Common.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Common
{
    public class CharacterGeneration
    {
        /// <summary>
        /// Generate the dynamic account screen to list possible character choices.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static string GetAccountScreen( PlayerConnection connection )
        {
            StringBuilder sb = new StringBuilder( );
            sb.AppendLine( ".------- ACCOUNT SCREEN -------------------------." );
            sb.AppendLine( string.Format( "| Account Name: {0,-33}|", connection.Account.AccountName ) );
            sb.AppendLine( "+------------------------------------------------+" );
            sb.AppendLine( "| Characters:                                    |" );
            if ( connection.Account.Characters.Count < 1 )
            {
                sb.AppendLine( "|  No characters. Type \"new\".                    |" );
            }
            else
            {
                foreach ( Character pc in connection.Account.Characters )
                {
                    sb.AppendLine( string.Format( "|  {0,-15} {1,-14} {2,-14} |", pc.Name, pc.Race.Name, pc.Class.Name ) );
                }
            }
            sb.AppendLine( "'------------------------------------------------'" );

            sb.Append( "Choose a character or type \"new\" to create a new one." );
            return sb.ToString( );
        }

        /// <summary>
        /// Generate the race selection screen for chargen.
        /// </summary>
        /// <returns></returns>
        public static string GetNewCharacterRaceScreen( List<Race> Races )
        {
            StringBuilder sb = new StringBuilder( );
            sb.AppendLine( ".------- RACES ----------------------------------." );
            sb.AppendLine( "| Choose a race to play:                         |" );
            sb.AppendLine( "+------------------------------------------------+" );
            foreach ( Race race in Races )
            {
                sb.AppendLine( string.Format( "|  {0,-45} |", race.Name ) );
            }
            sb.Append( "'------------------------------------------------'" );

            return sb.ToString( );
        }

        /// <summary>
        /// Generate the ancestry selection screen for chargen.
        /// </summary>
        /// <returns></returns>
        public static string GetNewCharacterAncestryScreen(List<Ancestry> Ancestries)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(".------- Ancestries -----------------------------.");
            sb.AppendLine("| Choose an ancestry to play:                    |");
            sb.AppendLine("+------------------------------------------------+");
            foreach (Ancestry ancestry in Ancestries)
            {
                sb.AppendLine(string.Format("|  {0,-45} |", ancestry.Name));
            }
            sb.Append("'------------------------------------------------'");

            return sb.ToString();
        }

        /// <summary>
        /// Generate the class selection screen for chargen.
        /// </summary>
        /// <returns></returns>
        public static string GetNewCharacterClassScreen( List<Class> Classes )
        {
            StringBuilder sb = new StringBuilder( );
            sb.AppendLine( ".------- CLASSES --------------------------------." );
            sb.AppendLine( "| Choose a class to play:                        |" );
            sb.AppendLine( "+------------------------------------------------+" );
            foreach ( Class c in Classes )
            {
                sb.AppendLine( string.Format( "|  {0,-45} |", c.Name ) );
            }
            sb.Append( "'------------------------------------------------'" );

            return sb.ToString( );
        }
    }
}
