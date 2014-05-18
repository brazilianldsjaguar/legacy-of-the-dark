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
    public class StarsignData : BaseData
    {
        public static List<Starsign> LoadStarsigns()
        {
            List<Starsign> starsigns = BaseData.GetDatabase().Starsigns.ToList();

            return starsigns;
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

        private static string GetStarsignPath()
        {
            return ServerConfiguration.ReadAppConfig("StarsignPath");
        }

        public static void StarsignClass(string name)
        {
            Starsign c = new Starsign() { Name = name };
            BaseData.GetDatabase().Starsigns.Add(c);
            GetDatabase( ).SaveChanges( );
        }
    }
}
