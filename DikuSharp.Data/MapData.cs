using DikuSharp.Common;
using DikuSharp.Common.Areas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Data.Entity;

namespace DikuSharp.Data
{
    public class MapData : BaseData
    {

        public static List<Map> LoadMaps( )
        {
            List<Map> maps = BaseData.GetDatabase( ).Maps.ToList( );           
            return maps;
        }

        public static void CreateMap(string name)
        {
            Map m = new Map();
            m.Name = name;
            BaseData.GetDatabase().Maps.Add(m);
            GetDatabase().SaveChanges();
        }
    }
}
