namespace DikuSharp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemRoomRelationship3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemRoom",
                c => new
                    {
                        Item_ID = c.Int(nullable: false),
                        Room_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_ID, t.Room_ID })
                .ForeignKey("dbo.Item", t => t.Item_ID, cascadeDelete: true)
                .ForeignKey("dbo.Room", t => t.Room_ID, cascadeDelete: true)
                .Index(t => t.Item_ID)
                .Index(t => t.Room_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemRoom", "Room_ID", "dbo.Room");
            DropForeignKey("dbo.ItemRoom", "Item_ID", "dbo.Item");
            DropIndex("dbo.ItemRoom", new[] { "Room_ID" });
            DropIndex("dbo.ItemRoom", new[] { "Item_ID" });
            DropTable("dbo.ItemRoom");
        }
    }
}
