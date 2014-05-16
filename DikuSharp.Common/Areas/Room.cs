using DikuSharp.Common.Characters;
using DikuSharp.Common.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DikuSharp.Common.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DikuSharp.Common.Areas
{
    public class Room
    {
        [Key]
        public int ID { get; set; }
        public int AreaID { get; set; }
        public virtual Area Area { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private ICollection<PlayerCharacter> _characters;
        public virtual ICollection<PlayerCharacter> Characters
        {
            get { return _characters ?? ( _characters = new List<PlayerCharacter>( ) ); }
            set { _characters = value; }
        }

        [NotMapped]
        public List<Mob> Mobs { get; set; }

        private ICollection<Item> _items;
        public virtual ICollection<Item> Items
        {
            get { return _items ?? ( _items = new List<Item>( ) ); }
            set { _items = value; }
        }

        #region Equal Overrides

        public override bool Equals( object obj )
        {
            Room a = obj as Room;
            if ( (object)a == null )
            {
                return false;
            }

            return ( a.ID == ID );
        }

        public static bool operator ==( Room a, Room b )
        {
            if ( ReferenceEquals( a, b ) )
                return true;

            if ( ( (object)a == null ) || ( (object)b == null ) )
                return false;

            return ( a.ID == b.ID );
        }

        public static bool operator !=( Room a, Room b )
        {
            return !( a == b );
        }

        public override int GetHashCode( )
        {
            return ID;
        }

        #endregion

        public override string ToString( )
        {
            return Name;
        }
    }
}
