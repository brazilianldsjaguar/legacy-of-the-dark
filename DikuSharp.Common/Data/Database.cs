using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Common.Data
{
    public static class Database
    {
        private static SqlCeEngine engine = new SqlCeEngine( )
        {
            LocalConnectionString =
                "Data Source=DikuSharpDatabase.sdf;Persist Security Info=false;Max Database Size=1024;Encrypt Database=true;Password=d|kU$h4Rp!?"
        };

        private static SqlCeConnection connection = null;

        private static void Initialize( )
        {
            if ( !File.Exists( "DikuSharpDatabase.sdf" ) )
            {
                engine.CreateDatabase( );
            }
        }

        //public SqlCeConnection Connect( )
        //{
        //    SqlCeConnection connection = new SqlCeConnection( engine.LocalConnectionString );
        //    return connection;
        //}

        public static void Close( )
        {
            Database.engine.Dispose( );
        }

        public static SqlCeConnection GetConnection( )
        {
            if ( connection == null )
            {
                Database.Initialize( );
                connection = new SqlCeConnection( engine.LocalConnectionString );
            }
            return connection;
        }
    }
}