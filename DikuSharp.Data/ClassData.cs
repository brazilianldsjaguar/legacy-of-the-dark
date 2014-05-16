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
    public class ClassData : BaseData
    {
        public static List<Class> LoadClasses( )
        {
            List<Class> classes = BaseData.GetDatabase( ).Classes.ToList( );

            return classes;
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

        private static string GetClassPath( )
        {
            return ServerConfiguration.ReadAppConfig( "ClassPath" );
        }

        public static void CreateClass( string name )
        {
            Class c = new Class( ) { Name = name };
            BaseData.GetDatabase( ).Classes.Add( c );
            GetDatabase( ).SaveChanges( );
        }
    }
}
