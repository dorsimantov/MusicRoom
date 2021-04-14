namespace MusicRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBands : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Bands (BandName) VALUES ('Saraf'), ('The Beatles')");
        }
        
        public override void Down()
        {
        }
    }
}
