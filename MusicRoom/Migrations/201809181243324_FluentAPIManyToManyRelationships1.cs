namespace MusicRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FluentAPIManyToManyRelationships1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.InstrumentBands", name: "Genre_Id", newName: "Band_Id");
            RenameIndex(table: "dbo.InstrumentBands", name: "IX_Genre_Id", newName: "IX_Band_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.InstrumentBands", name: "IX_Band_Id", newName: "IX_Genre_Id");
            RenameColumn(table: "dbo.InstrumentBands", name: "Band_Id", newName: "Genre_Id");
        }
    }
}
