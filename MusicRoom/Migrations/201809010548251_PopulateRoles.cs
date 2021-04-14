namespace MusicRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRoles : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Roles (RoleName) VALUES ('Player'), ('Admin'), ('Master')");
        }
        
        public override void Down()
        {
        }
    }
}
