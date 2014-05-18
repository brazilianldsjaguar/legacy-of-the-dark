using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DikuSharp.Common;
using DikuSharp.Common.Characters;
using System.Xml.Serialization;
using System.IO;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Data.Entity;

namespace DikuSharp.Data
{
    public class AccountData : BaseData
    {

        public static Account InitializeAccount( string name )
        {
            return new Account( ) { AccountName = name, Characters = new List<Character>( ) };
        }

        public static List<Account> LoadAccounts( )
        {
            List<Account> accounts = new List<Account>( );

            accounts = BaseData.GetDatabase( ).Accounts.ToList( );
                //BaseData.GetData<List<Account>, Account>( accounts, GetAccountPath( ), LoadAccount, "*.account" );

            return accounts;

            //foreach ( Account a in accounts )
            //{
            //    foreach ( PlayerCharacter pc in a.Characters )
            //    {
            //        pc.Account = a;
            //    }
            //}
            //return accounts;
        }

        public static void SaveAccounts( )
        {
            BaseData.GetDatabase( ).SaveChanges( );
        }
        
        private static Account LoadAccount( int id )
        {
            return BaseData.GetDatabase( ).Accounts.Find( id );
        }

        public static void SaveAccount( Account account )
        {
            //see if the account exists
            if ( BaseData.GetDatabase( ).Accounts.Find( account.ID ) == null )
            {
                //Add it
                BaseData.GetDatabase( ).Accounts.Add( account );
            }            
            BaseData.GetDatabase( ).SaveChanges( );
        }

        private static string GetAccountPath( )
        {
            return ServerConfiguration.ReadAppConfig( "AccountPath" );
        }

        public static Character CreatePlayerCharacter( Account account, string name )
        {
            account = BaseData.GetDatabase( ).Accounts.Find( account.ID );
            Character pc = new Character( );// BaseData.GetDatabase( ).Characters.Create( );
            pc.Name = name;

            //Just some defaults to satisfy foreign keys
            pc.Class = ClassData.GetDatabase( ).Classes.FirstOrDefault( );
            pc.Race = RaceData.GetDatabase( ).Races.FirstOrDefault( );
            pc.Ancestry = AncestryData.GetDatabase( ).Ancestries.FirstOrDefault( );
            pc.CurrentRoom = BaseData.GetDatabase( ).Rooms.FirstOrDefault( );
            pc.Controller = new PlayerController( ) { Account = account };
            account.Characters.Add( pc );
            BaseData.GetDatabase( ).SaveChanges( );
            return pc;
        }
    }
}
