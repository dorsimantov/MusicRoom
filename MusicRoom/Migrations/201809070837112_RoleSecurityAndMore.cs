namespace MusicRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleSecurityAndMore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instruments", "Instrument_Id", c => c.Int());
            AddColumn("dbo.Instruments", "Band_Id", c => c.Int());
            CreateIndex("dbo.Instruments", "Instrument_Id");
            CreateIndex("dbo.Instruments", "Band_Id");
            AddForeignKey("dbo.Instruments", "Instrument_Id", "dbo.Instruments", "Id");
            AddForeignKey("dbo.Instruments", "Band_Id", "dbo.Bands", "Id");
            DropColumn("dbo.Roles", "RoleName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "RoleName", c => c.String());
            DropForeignKey("dbo.Instruments", "Band_Id", "dbo.Bands");
            DropForeignKey("dbo.Instruments", "Instrument_Id", "dbo.Instruments");
            DropIndex("dbo.Instruments", new[] { "Band_Id" });
            DropIndex("dbo.Instruments", new[] { "Instrument_Id" });
            DropColumn("dbo.Instruments", "Band_Id");
            DropColumn("dbo.Instruments", "Instrument_Id");
        }
    }
}
