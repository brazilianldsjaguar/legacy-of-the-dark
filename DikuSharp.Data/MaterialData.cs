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
    public class MaterialData : BaseData
    {
        public static List<Material> LoadMaterials( )
        {
            List<Material> materials = BaseData.GetDatabase( ).Materials.ToList( );

            return materials;
        }

        private static string GetMaterialPath( )
        {
            return ServerConfiguration.ReadAppConfig( "MaterialPath" );
        }

        public static void CreateMaterial(string name,int hardness, int sharpness, int health, int weight, int valuemodifier )
        {

            Material m = new Material( ) { Name = name, Hardness = hardness, Sharpness = sharpness, Health = health, Weight = weight, ValueModifier = valuemodifier };
            BaseData.GetDatabase( ).Materials.Add( m );
            GetDatabase( ).SaveChanges( );
        }
    }
}
