namespace MusicRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateInstruments : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Instruments (Name) VALUES ('פסנתר'), ('גיטרה'), ('בס'), ('תופים'), ('כינור'), ('חליל') ");
        }
        
        public override void Down()
        {
        }
    }
}
