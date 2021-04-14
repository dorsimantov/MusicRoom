namespace MusicRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BandsInstruments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Instruments", "Instrument_Id", "dbo.Instruments");
            DropForeignKey("dbo.Instruments", "Band_Id", "dbo.Bands");
            DropIndex("dbo.Instruments", new[] { "Instrument_Id" });
            DropIndex("dbo.Instruments", new[] { "Band_Id" });
            CreateTable(
                "dbo.InstrumentBands",
                c => new
                    {
                        Instrument_Id = c.Int(nullable: false),
                        Band_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instrument_Id, t.Band_Id })
                .ForeignKey("dbo.Instruments", t => t.Instrument_Id, cascadeDelete: true)
                .ForeignKey("dbo.Bands", t => t.Band_Id, cascadeDelete: true)
                .Index(t => t.Instrument_Id)
                .Index(t => t.Band_Id);
            
            DropColumn("dbo.Instruments", "Instrument_Id");
            DropColumn("dbo.Instruments", "Band_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Instruments", "Band_Id", c => c.Int());
            AddColumn("dbo.Instruments", "Instrument_Id", c => c.Int());
            DropForeignKey("dbo.InstrumentBands", "Band_Id", "dbo.Bands");
            DropForeignKey("dbo.InstrumentBands", "Instrument_Id", "dbo.Instruments");
            DropIndex("dbo.InstrumentBands", new[] { "Band_Id" });
            DropIndex("dbo.InstrumentBands", new[] { "Instrument_Id" });
            DropTable("dbo.InstrumentBands");
            CreateIndex("dbo.Instruments", "Band_Id");
            CreateIndex("dbo.Instruments", "Instrument_Id");
            AddForeignKey("dbo.Instruments", "Band_Id", "dbo.Bands", "Id");
            AddForeignKey("dbo.Instruments", "Instrument_Id", "dbo.Instruments", "Id");
        }
    }
}
