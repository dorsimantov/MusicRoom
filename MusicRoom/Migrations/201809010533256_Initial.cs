namespace MusicRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BandName = c.String(),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        RoleId = c.Int(nullable: false),
                        MailSubscription = c.Boolean(nullable: false),
                        Band_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bands", t => t.Band_Id)
                .Index(t => t.Band_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Instruments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        TimeAndDate = c.DateTime(nullable: false),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        TimeAndDate = c.DateTime(nullable: false),
                        Body = c.String(),
                        CreatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GearRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestorId = c.Int(nullable: false),
                        AdminId = c.Int(nullable: false),
                        Reason = c.String(),
                        Gear = c.String(),
                        Where = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Need = c.String(),
                        Priority = c.String(),
                        ProductNumber = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        ContactPhone = c.String(),
                        RequestorId = c.Int(nullable: false),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Band_Id", "dbo.Bands");
            DropForeignKey("dbo.Instruments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Genres", "User_Id", "dbo.Users");
            DropIndex("dbo.Instruments", new[] { "User_Id" });
            DropIndex("dbo.Genres", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "Band_Id" });
            DropTable("dbo.Roles");
            DropTable("dbo.PurchaseRequests");
            DropTable("dbo.GearRequests");
            DropTable("dbo.Events");
            DropTable("dbo.Comments");
            DropTable("dbo.Instruments");
            DropTable("dbo.Genres");
            DropTable("dbo.Users");
            DropTable("dbo.Bands");
        }
    }
}
