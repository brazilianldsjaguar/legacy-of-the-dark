using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.IO;

namespace DikuSharp.Data
{
    public class Source
    {
        private SqlCeEngine engine;
        private SqlCeConnection connection = null;

        public Source( )
        {
            engine = new SqlCeEngine( );
            Initialize( );
        }

        private void Initialize( )
        {
            engine.LocalConnectionString = "Data Source=DikuSharpDatabase.sdf;Persist Security Info=false;Max Database Size=1024;Encrypt Database=true;Password=d|kU$h4Rp!?";
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

        public void Close( )
        {
            engine.Dispose( );
        }

        public SqlCeConnection GetConnection( )
        {
            if ( connection == null )
            {
                connection = new SqlCeConnection( engine.LocalConnectionString );
            }
            return connection;
        }
    }
}
