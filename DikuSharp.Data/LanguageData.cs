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
    public class LanguageData : BaseData
    {

        public static List<Common.Characters.Language> LoadMaps( )
        {
            List<Common.Characters.Language> language = BaseData.GetDatabase().Languages.ToList();           
            return language;
        }

        public static void CreateLanguage(string name)
        {
            Common.Characters.Language m = new Common.Characters.Language();
            m.Name = name;
            BaseData.GetDatabase().Languages.Add(m);
            GetDatabase().SaveChanges();
        }
    }
}
