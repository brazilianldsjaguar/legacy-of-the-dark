using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DikuSharp.Common
{
    public class Class
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public override string ToString( )
        {
            return Name;
        }

        #region Equal Overrides

        public override bool Equals( object obj )
        {
            Class a = obj as Class;
            if ( (object)a == null )
            {
                return false;
            }

            return ( a.Name == Name );
        }

        public static bool operator ==( Class a, Class b )
        {
            if ( ReferenceEquals( a, b ) )
                return true;

            if ( ( (object)a == null ) || ( (object)b == null ) )
                return false;

            return ( a.Name == b.Name );
        }

        public static bool operator !=( Class a, Class b )
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
