namespace MusicRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullNameNotRequiredTest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "FullName", c => c.String(nullable: false));
        }
    }
}
