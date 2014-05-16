using DikuSharp.Common.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DikuSharp.Common.Areas
{
    public class Area
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int LowLevel { get; set; }
        public int HighLevel { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }

        public void AddRoom( Room room )
        {
            if ( Rooms == null )
            {
                Rooms = new List<Room>( );
            }
            Rooms.Add( room );
        }

        public override string ToString( )
        {
            return Name;
        }

        #region Equal Overrides

        public override bool Equals( object obj )
        {
            Area a = obj as Area;
            if ( (object)a == null )
            {
                return false;
            }

            return ( a.Name == Name );
        }

        public static bool operator ==( Area a, Area b )
        {
            if ( ReferenceEquals( a, b ) )
                return true;

            if ( ( (object)a == null ) || ( (object)b == null ) )
                return false;

            return ( a.Name == b.Name );
        }

        public static bool operator !=( Area a, Area b )
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
