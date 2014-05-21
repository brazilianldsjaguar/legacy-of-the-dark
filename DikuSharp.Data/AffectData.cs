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
    public class AffectData : BaseData
    {
        public static List<Common.Characters.Affect> LoadAffects( )
        {
            List<Common.Characters.Affect> affects = BaseData.GetDatabase().Affects.ToList();

            return affects;
        }

        public static void CreateAffect( string name )
        {
            Common.Characters.Affect c = new Common.Characters.Affect() { Name = name };
            BaseData.GetDatabase( ).Affects.Add( c );
            GetDatabase( ).SaveChanges( );
        }
    }
}
