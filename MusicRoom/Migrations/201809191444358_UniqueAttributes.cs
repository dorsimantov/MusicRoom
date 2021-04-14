namespace MusicRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bands", "BandName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Instruments", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Inventories", "ProductNumber", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Inventories", "CatalogNumber", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Inventories", "SerialNumber", c => c.String(maxLength: 50));
            CreateIndex("dbo.Bands", "BandName", unique: true);
            CreateIndex("dbo.Genres", "Name", unique: true);
            CreateIndex("dbo.Users", "Username", unique: true);
            CreateIndex("dbo.Instruments", "Name", unique: true);
            CreateIndex("dbo.Inventories", "ProductNumber", unique: true);
            CreateIndex("dbo.Inventories", "CatalogNumber", unique: true);
            CreateIndex("dbo.Inventories", "SerialNumber", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Inventories", new[] { "SerialNumber" });
            DropIndex("dbo.Inventories", new[] { "CatalogNumber" });
            DropIndex("dbo.Inventories", new[] { "ProductNumber" });
            DropIndex("dbo.Instruments", new[] { "Name" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Genres", new[] { "Name" });
            DropIndex("dbo.Bands", new[] { "BandName" });
            AlterColumn("dbo.Inventories", "SerialNumber", c => c.String());
            AlterColumn("dbo.Inventories", "CatalogNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Inventories", "ProductNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Instruments", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Bands", "BandName", c => c.String(nullable: false));
        }
    }
}
