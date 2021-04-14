namespace MusicRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BandsInUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Band_Id", "dbo.Bands");
            DropIndex("dbo.Users", new[] { "Band_Id" });
            CreateTable(
                "dbo.UserBands",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Band_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Band_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Bands", t => t.Band_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Band_Id);
            
            DropColumn("dbo.Users", "Band_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Band_Id", c => c.Int());
            DropForeignKey("dbo.UserBands", "Band_Id", "dbo.Bands");
            DropForeignKey("dbo.UserBands", "User_Id", "dbo.Users");
            DropIndex("dbo.UserBands", new[] { "Band_Id" });
            DropIndex("dbo.UserBands", new[] { "User_Id" });
            DropTable("dbo.UserBands");
            CreateIndex("dbo.Users", "Band_Id");
            AddForeignKey("dbo.Users", "Band_Id", "dbo.Bands", "Id");
        }
    }
}
