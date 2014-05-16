namespace DikuSharp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedConfigColor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayerCharacter", "ConfigColor", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlayerCharacter", "ConfigColor");
        }
    }
}
