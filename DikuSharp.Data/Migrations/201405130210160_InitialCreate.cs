namespace DikuSharp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                {
                    ID = c.Int( nullable: false, identity: true ),
                    AccountName = c.String( nullable: false, maxLength: 4000 ),
                    Password = c.String( nullable: false, maxLength: 4000 ),
                } )
                .PrimaryKey( t => t.ID );

            CreateTable(
                "dbo.PlayerCharacter",
                c => new
                {
                    ID = c.Int( nullable: false, identity: true ),
                    AccountID = c.Int( nullable: false ),
                    AncestryID = c.Int(nullable: false),
                    ClassID = c.Int( nullable: false ),
                    RaceID = c.Int( nullable: false ),
                    RoomID = c.Int( nullable: false ),
                    Name = c.String( maxLength: 4000 ),
                    Description = c.String( maxLength: 4000 ),
                } )
                .PrimaryKey( t => t.ID )
                .ForeignKey( "dbo.Account", t => t.AccountID, cascadeDelete: true )
                .ForeignKey( "dbo.Class", t => t.ClassID, cascadeDelete: true )
                .ForeignKey( "dbo.Room", t => t.RoomID, cascadeDelete: true )
                .ForeignKey( "dbo.Race", t => t.RaceID, cascadeDelete: true )
                .ForeignKey("dbo.Ancestry", t => t.AncestryID, cascadeDelete: true)
                .Index( t => t.AccountID )
                .Index( t => t.ClassID )
                .Index( t => t.RaceID )
                .Index(t => t.AncestryID)
                .Index( t => t.RoomID );

            CreateTable(
                "dbo.Ancestry",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 4000),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Class",
                c => new
                {
                    ID = c.Int( nullable: false, identity: true ),
                    Name = c.String( maxLength: 4000 ),
                } )
                .PrimaryKey( t => t.ID );

            CreateTable(
                "dbo.Room",
                c => new
                {
                    ID = c.Int( nullable: false, identity: true ),
                    AreaID = c.Int( nullable: false ),
                    Name = c.String( maxLength: 4000 ),
                    Description = c.String( maxLength: 4000 ),
                } )
                .PrimaryKey( t => t.ID )
                .ForeignKey( "dbo.Area", t => t.AreaID, cascadeDelete: true )
                .Index( t => t.AreaID );

            CreateTable(
                "dbo.Area",
                c => new
                {
                    ID = c.Int( nullable: false, identity: true ),
                    Name = c.String( maxLength: 4000 ),
                    Author = c.String( maxLength: 4000 ),
                    LowLevel = c.Int( nullable: false ),
                    HighLevel = c.Int( nullable: false ),
                } )
                .PrimaryKey( t => t.ID );

            CreateTable(
                "dbo.Item",
                c => new
                {
                    ID = c.Int( nullable: false, identity: true ),
                    Keywords = c.String( nullable: false, maxLength: 4000 ),
                    ShortDescription = c.String( maxLength: 4000 ),
                    LongDescription = c.String( maxLength: 4000 ),
                    IsEquipped = c.Boolean( nullable: false ),
                } )
                .PrimaryKey( t => t.ID );

            CreateTable(
                "dbo.Race",
                c => new
                {
                    ID = c.Int( nullable: false, identity: true ),
                    Name = c.String( maxLength: 4000 ),
                } )
                .PrimaryKey( t => t.ID );

            CreateTable(
                "dbo.ItemPlayerCharacter",
                c => new
                {
                    Item_ID = c.Int( nullable: false ),
                    PlayerCharacter_ID = c.Int( nullable: false ),
                } )
                .PrimaryKey( t => new { t.Item_ID, t.PlayerCharacter_ID } )
                .ForeignKey( "dbo.Item", t => t.Item_ID, cascadeDelete: true )
                .ForeignKey( "dbo.PlayerCharacter", t => t.PlayerCharacter_ID, cascadeDelete: true )
                .Index( t => t.Item_ID )
                .Index( t => t.PlayerCharacter_ID );
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ancestry", "AncestryID", "dbo.Ancestry");
            DropForeignKey( "dbo.PlayerCharacter", "RaceID", "dbo.Race" );
            DropForeignKey( "dbo.ItemPlayerCharacter", "PlayerCharacter_ID", "dbo.PlayerCharacter" );
            DropForeignKey( "dbo.ItemPlayerCharacter", "Item_ID", "dbo.Item" );
            DropForeignKey( "dbo.PlayerCharacter", "RoomID", "dbo.Room" );
            DropForeignKey( "dbo.Room", "AreaID", "dbo.Area" );
            DropForeignKey( "dbo.PlayerCharacter", "ClassID", "dbo.Class" );
            DropForeignKey( "dbo.PlayerCharacter", "AccountID", "dbo.Account" );
            DropIndex( "dbo.ItemPlayerCharacter", new[ ] { "PlayerCharacter_ID" } );
            DropIndex( "dbo.ItemPlayerCharacter", new[ ] { "Item_ID" } );
            DropIndex( "dbo.Room", new[ ] { "AreaID" } );
            DropIndex( "dbo.PlayerCharacter", new[ ] { "RoomID" } );
            DropIndex( "dbo.PlayerCharacter", new[ ] { "RaceID" } );
            DropIndex("dbo.PlayerCharacter", new[] { "AncestryID" });
            DropIndex( "dbo.PlayerCharacter", new[ ] { "ClassID" } );
            DropIndex( "dbo.PlayerCharacter", new[ ] { "AccountID" } );
            DropTable( "dbo.ItemPlayerCharacter" );
            DropTable( "dbo.Race" );
            DropTable("dbo.Ancestry");
            DropTable( "dbo.Item" );
            DropTable( "dbo.Area" );
            DropTable( "dbo.Room" );
            DropTable( "dbo.Class" );
            DropTable( "dbo.PlayerCharacter" );
            DropTable( "dbo.Account" );
        }
    }
}
