namespace MusicRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InventoryModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        ProductNumber = c.String(nullable: false),
                        CatalogNumber = c.String(nullable: false),
                        SerialNumber = c.String(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Inventories");
        }
    }
}
