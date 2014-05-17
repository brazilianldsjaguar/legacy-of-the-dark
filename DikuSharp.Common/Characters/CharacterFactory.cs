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
        public Character CreateMob( )
        {
            AIController AI = new AIController();
            Character m = new Character( );
            m.Controller = AI;
            m.Inventory = new List<Item>( );
            return m;
        }

        public static Character CreatePlayerCharacter( Account account, string characterName )
        {
            PlayerController pc = new PlayerController( );
            Character newC = new Character();
            newC.Name = characterName;
            newC.Items = new List<Item>();
            newC.Controller = pc;
            account.Characters.Add( newC );            
            return newC;
        }
    }
}
