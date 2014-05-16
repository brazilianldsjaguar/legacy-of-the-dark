using DikuSharp.Common.Areas;
using DikuSharp.Common.Characters;
using DikuSharp.Common.Extensions;
using DikuSharp.Common.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Mud.Logic
{
    public static class RoomLogic
    {
        public static string GetRoomInformation( Room room, PlayerCharacter looker = null )
        {
            StringBuilder sb = new StringBuilder( );
            sb.AppendLine( room.Name );
            foreach ( string descLine in room.Description.SplitByLength( 50 ).ToArray( ) )
            {
                sb.AppendLine( string.Format( "  #B{0}#x", descLine ) );
            }
            foreach ( PlayerCharacter ch in room.Characters )
            {
                if ( looker != null )
                {
                    if ( looker == ch )
                    {
                        continue;
                    }
                }
                //If 
                if ( !ch.IsPlaying || ( ch.IsPlaying && ch.Account.CurrentCharacter != ch ) )
                {
                    continue;
                }

                sb.AppendLine( "#W" + ch.Name );
            }
            foreach ( Item item in room.Items )
            {
                sb.AppendLine( item.ShortDescription );
            }
            //foreach ( Mob mob in room.Mobs )
            //{
            //    sb.AppendLine( mob.Name );
            //}
            return sb.ToString( );
        }

        public static void MoveCharacterToRoom( PlayerCharacter ch, Room fromRoom, Room toRoom )
        {
            //This takes care of new characters and those logging in
            if ( fromRoom != null )
            {
                fromRoom.Characters.Remove( ch );
            }

            //If the toRoom and the player's CurrentRoom are the same, there's no need to move!
            if ( ch.CurrentRoom != toRoom )
            {
                ch.CurrentRoom = toRoom;
                toRoom.Characters.Add( ch );
            }
        }

        public static void MoveCharacterToRoom( Mob ch, Room fromRoom, Room toRoom )
        {
            fromRoom.Mobs.Remove( ch );
            ch.CurrentRoom = toRoom;
            toRoom.Mobs.Add( ch );
        }
    }
}
