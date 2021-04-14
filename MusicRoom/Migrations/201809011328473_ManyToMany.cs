namespace MusicRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genres", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Instruments", "User_Id", "dbo.Users");
            DropIndex("dbo.Genres", new[] { "User_Id" });
            DropIndex("dbo.Instruments", new[] { "User_Id" });
            CreateTable(
                "dbo.GenreBands",
                c => new
                    {
                        Genre_Id = c.Int(nullable: false),
                        Band_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Band_Id })
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.Bands", t => t.Band_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Band_Id);
            
            CreateTable(
                "dbo.UserGenres",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Genre_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Genre_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Genre_Id);
            
            CreateTable(
                "dbo.InstrumentUsers",
                c => new
                    {
                        Instrument_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instrument_Id, t.User_Id })
                .ForeignKey("dbo.Instruments", t => t.Instrument_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Instrument_Id)
                .Index(t => t.User_Id);
            
            DropColumn("dbo.Bands", "Genre");
            DropColumn("dbo.Genres", "User_Id");
            DropColumn("dbo.Instruments", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Instruments", "User_Id", c => c.Int());
            AddColumn("dbo.Genres", "User_Id", c => c.Int());
            AddColumn("dbo.Bands", "Genre", c => c.String());
            DropForeignKey("dbo.InstrumentUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.InstrumentUsers", "Instrument_Id", "dbo.Instruments");
            DropForeignKey("dbo.UserGenres", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.UserGenres", "User_Id", "dbo.Users");
            DropForeignKey("dbo.GenreBands", "Band_Id", "dbo.Bands");
            DropForeignKey("dbo.GenreBands", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.InstrumentUsers", new[] { "User_Id" });
            DropIndex("dbo.InstrumentUsers", new[] { "Instrument_Id" });
            DropIndex("dbo.UserGenres", new[] { "Genre_Id" });
            DropIndex("dbo.UserGenres", new[] { "User_Id" });
            DropIndex("dbo.GenreBands", new[] { "Band_Id" });
            DropIndex("dbo.GenreBands", new[] { "Genre_Id" });
            DropTable("dbo.InstrumentUsers");
            DropTable("dbo.UserGenres");
            DropTable("dbo.GenreBands");
            CreateIndex("dbo.Instruments", "User_Id");
            CreateIndex("dbo.Genres", "User_Id");
            AddForeignKey("dbo.Instruments", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Genres", "User_Id", "dbo.Users", "Id");
        }
    }
}
