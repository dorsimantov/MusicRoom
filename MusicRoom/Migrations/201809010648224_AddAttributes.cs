namespace MusicRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bands", "BandName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Instruments", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "Body", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.GearRequests", "AdminId", c => c.Int());
            AlterColumn("dbo.GearRequests", "Reason", c => c.String(nullable: false));
            AlterColumn("dbo.GearRequests", "Gear", c => c.String(nullable: false));
            AlterColumn("dbo.GearRequests", "Where", c => c.String(nullable: false));
            AlterColumn("dbo.GearRequests", "IsApproved", c => c.Boolean());
            AlterColumn("dbo.PurchaseRequests", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.PurchaseRequests", "Need", c => c.String(nullable: false));
            AlterColumn("dbo.PurchaseRequests", "IsApproved", c => c.Boolean());
            AlterColumn("dbo.PurchaseRequests", "ContactPhone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseRequests", "ContactPhone", c => c.String());
            AlterColumn("dbo.PurchaseRequests", "IsApproved", c => c.Boolean(nullable: false));
            AlterColumn("dbo.PurchaseRequests", "Need", c => c.String());
            AlterColumn("dbo.PurchaseRequests", "Title", c => c.String());
            AlterColumn("dbo.GearRequests", "IsApproved", c => c.Boolean(nullable: false));
            AlterColumn("dbo.GearRequests", "Where", c => c.String());
            AlterColumn("dbo.GearRequests", "Gear", c => c.String());
            AlterColumn("dbo.GearRequests", "Reason", c => c.String());
            AlterColumn("dbo.GearRequests", "AdminId", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "Title", c => c.String());
            AlterColumn("dbo.Comments", "Body", c => c.String());
            AlterColumn("dbo.Instruments", "Name", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Bands", "BandName", c => c.String());
        }
    }
}
