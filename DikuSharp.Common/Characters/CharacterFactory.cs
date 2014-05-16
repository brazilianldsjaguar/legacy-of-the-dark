using DikuSharp.Common.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Common.Characters
{
    public class CharacterFactory
    {
        public Mob CreateMob( )
        {
            Mob m = new Mob( );
            m.Inventory = new List<Item>( );
            return m;
        }

        public static PlayerCharacter CreatePlayerCharacter( Account account, string characterName )
        {
            PlayerCharacter pc = new PlayerCharacter( );
            pc.Name = characterName;
            pc.Items = new List<Item>( );
            account.Characters.Add( pc );            
            return pc;
        }
    }
}
