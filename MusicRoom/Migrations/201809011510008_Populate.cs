namespace MusicRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Populate : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO UserBands (User_Id, Band_Id) VALUES (17 , 1), (17 , 2)");
            Sql("INSERT INTO InstrumentUsers (Instrument_Id, User_Id) VALUES (1 , 17), (6, 17)");
        }
        
        public override void Down()
        {
        }
    }
}
