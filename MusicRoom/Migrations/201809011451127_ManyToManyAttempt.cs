namespace MusicRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyAttempt : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO UserBands (User_Id, Band_Id) VALUES (4 , 1), (4 , 2)");
        }
        
        public override void Down()
        {
        }
    }
}
