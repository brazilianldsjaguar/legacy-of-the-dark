namespace DikuSharp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemRoomRelationship2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Item", "Room_ID", "dbo.Room");
            DropIndex("dbo.Item", new[] { "Room_ID" });
            DropColumn("dbo.Item", "Room_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "Room_ID", c => c.Int());
            CreateIndex("dbo.Item", "Room_ID");
            AddForeignKey("dbo.Item", "Room_ID", "dbo.Room", "ID");
        }
    }
}
