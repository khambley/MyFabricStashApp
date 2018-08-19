namespace MyFabricStashApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVirtualSourceToReceipts : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Receipts", "SourceId");
            AddForeignKey("dbo.Receipts", "SourceId", "dbo.Sources", "SourceId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receipts", "SourceId", "dbo.Sources");
            DropIndex("dbo.Receipts", new[] { "SourceId" });
        }
    }
}
