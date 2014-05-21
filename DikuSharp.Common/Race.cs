using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DikuSharp.Common
{
    public class Race
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public override string ToString( )
        {
            return Name;
        }

        public virtual IList<Common.Characters.AttributeBonus> AttributeBonus { get; set; }
        public virtual IList<Common.Characters.ResistBonus> ResistBonus { get; set; }

        public int expBonus { get; set; }
        public virtual IList<Common.Characters.Language> racialLanguage { get; set; }
        public virtual IList<Common.Characters.Affect> racialAffects { get; set; }

        #region Equal Overrides

        public override bool Equals( object obj )
        {
            Race a = obj as Race;
            if ( (object)a == null )
            {
                return false;
            }

            return ( a.Name == Name );
        }

        public static bool operator ==( Race a, Race b )
        {
            if ( ReferenceEquals( a, b ) )
                return true;

            if ( ( (object)a == null ) || ( (object)b == null ) )
                return false;

            return ( a.Name == b.Name );
        }

        public static bool operator !=( Race a, Race b )
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
