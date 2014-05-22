using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DikuSharp.Common.Characters;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DikuSharp.Common
{
    public class Account
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string AccountName { get; set; }
        [Required]
        public string Password { get; set; }
        public virtual IList<Character> Characters { get; set; }
        
        [NotMapped]
        public PlayerConnection CurrentConnection { get; set; }
        [NotMapped]
        public Character CurrentCharacter { get; set; }
        [NotMapped]
        public Character CurrentPlayerController { get; set; }

        #region Equal Overrides

        public override bool Equals( object obj )
        {
            Account a = obj as Account;
            if ( (object)a == null )
            {
                return false;
            }

            return ( a.AccountName == AccountName );
        }

        public static bool operator ==( Account a, Account b )
        {
            if ( ReferenceEquals( a, b ) )
                return true;

            if ( ( (object)a == null ) || ( (object)b == null ) )
                return false;

            return ( a.AccountName == b.AccountName );
        }

        public static bool operator !=( Account a, Account b )
        {
            return !( a == b );
        }

        public override int GetHashCode( )
        {
            return AccountName.GetHashCode( );
        }

        #endregion

        public override string ToString( )
        {
            return AccountName;
        }
    }
}
