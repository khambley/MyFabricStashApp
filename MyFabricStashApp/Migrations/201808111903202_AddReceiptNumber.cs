namespace MyFabricStashApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReceiptNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receipts", "ReceiptNumber", c => c.String());
            AddColumn("dbo.Receipts", "SourceId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Receipts", "SourceId");
            DropColumn("dbo.Receipts", "ReceiptNumber");
        }
    }
}
