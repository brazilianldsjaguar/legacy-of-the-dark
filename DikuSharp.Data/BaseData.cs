using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DikuSharp.Data
{
    public class BaseData
    {
        private static DikuSharpDatabase _db = new DikuSharpDatabase( );
        public static DikuSharpDatabase GetDatabase( )
        {
            if ( _db == null )
            {
                _db = new DikuSharpDatabase( );
            }
            return _db;
        }
        //internal static TList GetData<TList, T>( TList listToFill, string pathToSearch, Func<string, T> LoadFunction, string fileNameFilter = "*" ) where TList : List<T> 
        //{
        //    //Get all the file information
        //    DirectoryInfo di = new DirectoryInfo( pathToSearch );
        //    FileInfo[ ] files = di.GetFiles( fileNameFilter );
        //    foreach ( FileInfo file in files )
        //    {
        //        listToFill.Add( LoadFunction( file.FullName ) );
        //    }

        //    return listToFill;
        //}

        //internal static T GetItem<T>( string fullPath )
        //{
        //    T item;
        //    XmlSerializer xml = new XmlSerializer( typeof( T ) );
        //    using ( StreamReader sr = new StreamReader( File.Open( fullPath, FileMode.Open ) ) )
        //    {
        //        item = (T)xml.Deserialize( sr );
        //    }
        //    return item;
        //}

        //internal static void SaveData<TList, T>( TList listToSave, Action<T> SaveFunction ) where TList : List<T>
        //{
        //    foreach ( T item in listToSave )
        //    {
        //        SaveFunction( item );                
        //    }
        //}

        //internal static void SaveItem<T>( T itemToSave, string dirPath, string propertyName, string fileExtension ) where T: class
        //{
        //    string name = itemToSave.GetType( ).GetProperty( propertyName ).GetValue( itemToSave ) as string;
        //    string fullPath = string.Format( "{0}{1}.{2}", dirPath, name.Replace(" ", "").ToLower( ), fileExtension );

        //    //Serialize the data
        //    XmlSerializer xml = new XmlSerializer( typeof(T) );
        //    using ( StreamWriter sw = new StreamWriter( File.Open( fullPath, FileMode.OpenOrCreate ) ) )
        //    {
        //        xml.Serialize( sw, itemToSave );
        //    }
        //}
    }
}
