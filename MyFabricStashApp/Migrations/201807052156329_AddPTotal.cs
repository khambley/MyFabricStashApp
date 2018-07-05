namespace MyFabricStashApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPTotal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "PurchaseTotal", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "PurchaseTotal");
        }
    }
}
