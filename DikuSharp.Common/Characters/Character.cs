using DikuSharp.Common.Areas;
using DikuSharp.Common.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Common.Characters
{
    public class Character
    {
        public string Name { get; set; }
        public List<Item> Inventory { get; set; }
        public List<Item> Equipment { get; set; }
        public Room CurrentRoom { get; set; }

        public override string ToString( )
        {
            return Name;
        }

        #region Equal Overrides

        public override bool Equals( object obj )
        {
            Character a = obj as Character;
            if ( (object)a == null )
            {
                return false;
            }

            return ( a.Name == Name );
        }

        public static bool operator ==( Character a, Character b )
        {
            if ( ReferenceEquals( a, b ) )
                return true;

            if ( ( (object)a == null ) || ( (object)b == null ) )
                return false;

            return ( a.Name == b.Name );
        }

        public static bool operator !=( Character a, Character b )
        {
            return !( a == b );
        }

        public override int GetHashCode( )
        {
            return Name.GetHashCode( );
        }

        #endregion
    }
}
