using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Data
{
    public static class ServerConfiguration
    {
        public static string ReadAppConfig( string key )
        {
            //Get area list file path
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap( );
            fileMap.ExeConfigFilename = string.Format( "{0}.config", System.Diagnostics.Process.GetCurrentProcess( ).MainModule.FileName );
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration( fileMap, ConfigurationUserLevel.None );
            return config.AppSettings.Settings[ key ].Value;
        }
    }
}
