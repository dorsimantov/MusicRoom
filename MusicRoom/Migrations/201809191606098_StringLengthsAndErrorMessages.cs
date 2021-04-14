namespace MusicRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringLengthsAndErrorMessages : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseRequests", "Title", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.PurchaseRequests", "Need", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.PurchaseRequests", "ProductNumber", c => c.String(maxLength: 50));
            AlterColumn("dbo.PurchaseRequests", "ContactPhone", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseRequests", "ContactPhone", c => c.String(nullable: false));
            AlterColumn("dbo.PurchaseRequests", "ProductNumber", c => c.String());
            AlterColumn("dbo.PurchaseRequests", "Need", c => c.String(nullable: false));
            AlterColumn("dbo.PurchaseRequests", "Title", c => c.String(nullable: false));
        }
    }
}
