namespace MyFabricStashApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchasesListViewModel : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Purchases", "ReceiptId");
            CreateIndex("dbo.Purchases", "SourceId");
            AddForeignKey("dbo.Purchases", "ReceiptId", "dbo.Receipts", "ReceiptId", cascadeDelete: true);
            AddForeignKey("dbo.Purchases", "SourceId", "dbo.Sources", "SourceId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "SourceId", "dbo.Sources");
            DropForeignKey("dbo.Purchases", "ReceiptId", "dbo.Receipts");
            DropIndex("dbo.Purchases", new[] { "SourceId" });
            DropIndex("dbo.Purchases", new[] { "ReceiptId" });
        }
    }
}
