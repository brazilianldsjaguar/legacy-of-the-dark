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
    public class RaceData : BaseData
    {
        public static List<Race> LoadRaces( )
        {
            List<Race> races = BaseData.GetDatabase( ).Races.ToList( );

            return races;
        }

        //public static void SaveRaces( List<Race> races )
        //{
        //    BaseData.SaveData<List<Race>, Race>( races, SaveRace );
        //}

        //private static Race LoadRace( string raceFile )
        //{
        //    return BaseData.GetItem<Race>( raceFile );
        //}

        //public static void SaveRace( Race race )
        //{
        //    BaseData.SaveItem<Race>( race, GetRacePath( ), "Name", "race" );
        //}

        //private static string GetRacePath( )
        //{
        //    return ServerConfiguration.ReadAppConfig( "RacePath" );
        //}
    }
}
