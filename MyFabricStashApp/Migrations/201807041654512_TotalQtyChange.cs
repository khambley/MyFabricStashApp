namespace MyFabricStashApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TotalQtyChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fabrics", "TotalQty", c => c.Double(nullable: false));
            DropColumn("dbo.Fabrics", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fabrics", "Quantity", c => c.Double(nullable: false));
            DropColumn("dbo.Fabrics", "TotalQty");
        }
    }
}
