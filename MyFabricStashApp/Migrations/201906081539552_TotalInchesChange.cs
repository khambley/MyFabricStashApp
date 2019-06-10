namespace MyFabricStashApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TotalInchesChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fabrics", "TotalInches", c => c.Double(nullable: false));
            DropColumn("dbo.Fabrics", "TotalQty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fabrics", "TotalQty", c => c.Double(nullable: false));
            DropColumn("dbo.Fabrics", "TotalInches");
        }
    }
}
