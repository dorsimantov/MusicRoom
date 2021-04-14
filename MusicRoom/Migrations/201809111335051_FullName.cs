namespace MusicRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FullName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "FullName");
        }
    }
}
