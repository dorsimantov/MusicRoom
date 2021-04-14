namespace MusicRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyPopulationAttempt : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO InstrumentUsers (Instrument_Id, User_Id) VALUES (1 , 4)");
        }
        
        public override void Down()
        {
        }
    }
}
