using DikuSharp.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DikuSharp.Data
{
    public class AncestryData : BaseData
    {
        public static List<Ancestry> LoadAncestries( )
        {
            List<Ancestry> ancestries = BaseData.GetDatabase( ).Ancestries.ToList( );

            return ancestries;
        }

        //public static void SaveClasses( List<Class> classes )
        //{
        //    BaseData.SaveData<List<Class>, Class>( classes, SaveClass );
        //}

        //private static Class LoadClass( string classFile )
        //{
        //    return BaseData.GetItem<Class>( classFile );
        //}

        //private static void SaveClass( Class c )
        //{
        //    BaseData.SaveItem<Class>( c, GetClassPath( ), "Name", "class" );
        //}

        private static string GetAncestryPath( )
        {
            return ServerConfiguration.ReadAppConfig( "AncestryPath" );
        }

        public static void AncestryClass( string name )
        {
            Ancestry c = new Ancestry( ) { Name = name };
            BaseData.GetDatabase( ).Ancestries.Add( c );
            GetDatabase( ).SaveChanges( );
        }
    }
}
