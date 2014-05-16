namespace DikuSharp.Data.Migrations
{
    using DikuSharp.Common;
    using DikuSharp.Common.Areas;
    using DikuSharp.Common.Characters;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DikuSharp.Data.DikuSharpDatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DikuSharp.Data.DikuSharpDatabase context)
        {
            //  This method will be called after migrating to the latest version.

            context.Classes.AddOrUpdate(
                c => c.Name,
                new Class { Name = "Warrior" },
                new Class { Name = "Mage" }
                );

            context.Races.AddOrUpdate(
                r => r.Name,
                new Race { Name = "Human" }
                );

            context.Areas.AddOrUpdate(
                a => a.ID,
                new Area { ID = 1, Name = "MudCore", Author = "Frosk", LowLevel = 0, HighLevel = 0 }
                );

            context.Rooms.AddOrUpdate(
                r => r.Name,
                new Room { Name = "Limbo", AreaID = 1, Description = "You shouldn't be here." } 
            );

            context.Accounts.AddOrUpdate(
                a => a.AccountName,
                new Account( ) { ID = 1, AccountName = "Frosk", Password = "29DF21D42A8156A94E61EF3DE17C298FFC8AB35461FBA64CECE81720E3611875" },
                new Account( ) { ID = 2, AccountName = "Tradkin", Password = "29DF21D42A8156A94E61EF3DE17C298FFC8AB35461FBA64CECE81720E3611875" }
            );

            context.Characters.AddOrUpdate(
                pc => pc.ID,
                new PlayerCharacter( ) { ID = 1, AccountID = 1, ClassID = 1, RaceID = 1, ConfigColor = true, Name = "Frosk", RoomID = 1 },
                new PlayerCharacter( ) { ID = 2, AccountID = 1, ClassID = 1, RaceID = 1, ConfigColor = true, Name = "FroskII", RoomID = 1 },
                new PlayerCharacter( ) { ID = 3, AccountID = 2, ClassID = 1, RaceID = 1, ConfigColor = true, Name = "Tradkin", RoomID = 1 }
            );


            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
