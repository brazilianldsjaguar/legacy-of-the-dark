using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Data.Entity;
using DikuSharp.Common;
using DikuSharp.Common.Characters;

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
            pc.Starsign = StarsignData.GetDatabase( ).Starsigns.FirstOrDefault();
            pc.CurrentRoom = BaseData.GetDatabase( ).Rooms.FirstOrDefault( );
            pc.Controller = new PlayerController( ) { Account = account };
            //Populate the default attributes
            pc.Attributes = new List<DikuSharp.Common.Characters.Attribute>( ) 
            {
                new DikuSharp.Common.Characters.Attribute( ) { Bonus = new AttributeBonus( ) { BonusAmount = 0 }, Type = AttributeType.Strength, Value = 5 },
                new DikuSharp.Common.Characters.Attribute( ) { Bonus = new AttributeBonus( ) { BonusAmount = 0 }, Type = AttributeType.Dexterity, Value = 5 },
                new DikuSharp.Common.Characters.Attribute( ) { Bonus = new AttributeBonus( ) { BonusAmount = 0 }, Type = AttributeType.Constituion, Value = 5 },
                new DikuSharp.Common.Characters.Attribute( ) { Bonus = new AttributeBonus( ) { BonusAmount = 0 }, Type = AttributeType.Intelligence, Value = 5 },
                new DikuSharp.Common.Characters.Attribute( ) { Bonus = new AttributeBonus( ) { BonusAmount = 0 }, Type = AttributeType.Wisdom, Value = 5 },
                new DikuSharp.Common.Characters.Attribute( ) { Bonus = new AttributeBonus( ) { BonusAmount = 0 }, Type = AttributeType.Charisma, Value = 5 },
                new DikuSharp.Common.Characters.Attribute( ) { Bonus = new AttributeBonus( ) { BonusAmount = 0 }, Type = AttributeType.Luck, Value = 5 },
            };
            //Populate the default resists
            pc.Resists = new List<DikuSharp.Common.Characters.Resist>() 
            {
                new DikuSharp.Common.Characters.Resist( ) { Bonus = new ResistBonus( ) { BonusAmount = 0 }, Type = ResistType.Acid, Value = 0 },
                new DikuSharp.Common.Characters.Resist( ) { Bonus = new ResistBonus( ) { BonusAmount = 0 }, Type = ResistType.Air, Value = 0 },
                new DikuSharp.Common.Characters.Resist( ) { Bonus = new ResistBonus( ) { BonusAmount = 0 }, Type = ResistType.Blunt, Value = 0 },
                new DikuSharp.Common.Characters.Resist( ) { Bonus = new ResistBonus( ) { BonusAmount = 0 }, Type = ResistType.Cold, Value = 0 },
                new DikuSharp.Common.Characters.Resist( ) { Bonus = new ResistBonus( ) { BonusAmount = 0 }, Type = ResistType.Crystal, Value = 0 },
                new DikuSharp.Common.Characters.Resist( ) { Bonus = new ResistBonus( ) { BonusAmount = 0 }, Type = ResistType.Earth, Value = 0 },
                new DikuSharp.Common.Characters.Resist( ) { Bonus = new ResistBonus( ) { BonusAmount = 0 }, Type = ResistType.Electricity, Value = 0 },
                new DikuSharp.Common.Characters.Resist( ) { Bonus = new ResistBonus( ) { BonusAmount = 0 }, Type = ResistType.Fire, Value = 0 },
                new DikuSharp.Common.Characters.Resist( ) { Bonus = new ResistBonus( ) { BonusAmount = 0 }, Type = ResistType.Nature, Value = 0 },
                new DikuSharp.Common.Characters.Resist( ) { Bonus = new ResistBonus( ) { BonusAmount = 0 }, Type = ResistType.Pierce, Value = 0 },
                new DikuSharp.Common.Characters.Resist( ) { Bonus = new ResistBonus( ) { BonusAmount = 0 }, Type = ResistType.Poison, Value = 0 },
                new DikuSharp.Common.Characters.Resist( ) { Bonus = new ResistBonus( ) { BonusAmount = 0 }, Type = ResistType.Slash, Value = 0 },
                new DikuSharp.Common.Characters.Resist( ) { Bonus = new ResistBonus( ) { BonusAmount = 0 }, Type = ResistType.Magic, Value = 0 },
            };
            account.Characters.Add( pc );
            BaseData.GetDatabase( ).SaveChanges( );
            return pc;
        }
    }
}
