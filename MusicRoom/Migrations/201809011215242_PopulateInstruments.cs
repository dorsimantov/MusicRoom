namespace MusicRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateInstruments : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Instruments (Name) VALUES ('�����'), ('�����'), ('��'), ('�����'), ('�����'), ('����') ");
        }
        
        public override void Down()
        {
        }
    }
}
