using DikuSharp.Common.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Commands.Common
{
    public class Score : CommandBase
    {
        public override void Do( object source, List<string> args )
        {
            if ( source is Character )
            {
                Character ch = source as Character;

                StringBuilder sb = new StringBuilder( );
                sb.AppendLine( "#G::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::#x" );
                sb.AppendLine( string.Format( "#G  Name: #W{0,-15}#x{1}", ch.Name, " ".PadRight( 47 ) ) );
                sb.AppendLine( "#G::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::#x" );
                sb.AppendLine( string.Format( "#G      Strength: #x{0,-3}{1}", ch.Strength.TotalValue,     " ".PadRight( 51 ) ) );
                sb.AppendLine( string.Format( "#G     Dexterity: #x{0,-3}{1}", ch.Dexterity.TotalValue,    " ".PadRight( 51 ) ) );
                sb.AppendLine( string.Format( "#G   Constituion: #x{0,-3}{1}", ch.Constituion.TotalValue,  " ".PadRight( 51 ) ) );
                sb.AppendLine( string.Format( "#G  Intelligence: #x{0,-3}{1}", ch.Intelligence.TotalValue, " ".PadRight( 51 ) ) );
                sb.AppendLine( string.Format( "#G        Wisdom: #x{0,-3}{1}", ch.Wisdom.TotalValue,       " ".PadRight( 51 ) ) );
                sb.AppendLine( string.Format( "#G      Charisma: #x{0,-3}{1}", ch.Charisma.TotalValue,     " ".PadRight( 51 ) ) );
                sb.AppendLine( string.Format( "#G          Luck: #x{0,-3}{1}", ch.Luck.TotalValue,         " ".PadRight( 51 ) ) );
                sb.AppendLine( "#G::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::#x" );

                ch.Send( sb.ToString( ) );

            }
        }
    }
}
