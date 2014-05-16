using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DikuSharp.Common.Extensions
{
    public static class TypeExtensions
    {
        public static string ToTitleCase( this string s )
        {
            if ( string.IsNullOrEmpty( s ) )
                return string.Empty;

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase( s );
        }

        public static IEnumerable<string> SplitByLength( this string s, int length )
        {
            for ( int i = 0 ; i < s.Length ; i += length )
            {
                if ( i + length <= s.Length )
                {
                    yield return s.Substring( i, length );
                }
                else
                {
                    yield return s.Substring( i );
                }
            }
        }
    }
}
