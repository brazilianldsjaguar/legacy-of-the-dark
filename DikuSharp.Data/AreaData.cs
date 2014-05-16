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
    public class AreaData : BaseData
    {
        ///// <summary>
        ///// Gets the path to all the areas (including the list) from the exe.config file
        ///// </summary>
        ///// <returns>A string of the path from the config file.</returns>
        //private static string GetAreaPath( )
        //{
        //    return ServerConfiguration.ReadAppConfig( "AreaPath" );
        //}

        /// <summary>
        /// Attempts to load up all the areas into the MUD
        /// </summary>
        /// <returns></returns>
        public static List<Area> LoadAreas( )
        {
            List<Area> areas = BaseData.GetDatabase( ).Areas.ToList( );           
            return areas;
        }

        public static void SaveAreas( List<Area> areas )
        {
            //Get a list of current areas:
            List<Area> currentAreas = LoadAreas( );

            foreach ( Area a in areas )
            {
                if ( currentAreas.Contains( a ) )
                {
                    BaseData.GetDatabase( ).Areas.Attach( a );
                    var ar = BaseData.GetDatabase( ).Entry( a ).State = EntityState.Modified;
                }
                else
                {
                    BaseData.GetDatabase( ).Areas.Add( a );
                }
            }
            BaseData.GetDatabase( ).SaveChanges( );
        }

        ///// <summary>
        ///// Save a collection of areas
        ///// </summary>
        ///// <param name="areas"></param>
        //public static void SaveAreas( List<Area> areas )
        //{
        //    BaseData.SaveData<List<Area>, Area>( areas, SaveArea );
        //}

        ///// <summary>
        ///// Load one specific area.
        ///// </summary>
        ///// <param name="area">The file name (such as test.are)</param>
        ///// <returns></returns>
        //private static Area LoadArea( string area )
        //{
        //    return BaseData.GetItem<Area>( area );            
        //}

        ///// <summary>
        ///// Save one specific area.
        ///// </summary>
        ///// <param name="area"></param>
        //private static void SaveArea( Area area )
        //{
        //    BaseData.SaveItem<Area>( area, GetAreaPath( ), "Name", "area" );
        //}
    }
}
