﻿using DikuSharp.Common;
using DikuSharp.Common.Areas;
using DikuSharp.Common.Characters;
using DikuSharp.Common.Items;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Data
{
    public class DikuSharpDatabase : DbContext
    {
        public DikuSharpDatabase( )
            : base( "DikuSharpDatabase" )
        {
            //Database.SetInitializer<DikuSharpDatabase>( new MigrateDatabaseToLatestVersion<DikuSharpDatabase, Migrations.Configuration>( ) );
            Database.SetInitializer<DikuSharpDatabase>( new DropCreateDatabaseAlways<DikuSharpDatabase>( ) );
            
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine( s );
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Ancestry> Ancestries { get; set; }
        public DbSet<Class> Classes { get; set; }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>( );
            //modelBuilder.Entity<Room>( ).HasOptional( r => r.Characters )
        }

        
    }
}
