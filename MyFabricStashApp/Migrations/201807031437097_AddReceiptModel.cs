namespace MyFabricStashApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReceiptModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "ReceiptId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "ReceiptId");
        }
    }
}
