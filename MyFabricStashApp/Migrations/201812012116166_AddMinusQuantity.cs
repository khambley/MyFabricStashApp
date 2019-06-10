namespace MyFabricStashApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMinusQuantity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fabrics", "AddQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Fabrics", "MinusQuantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fabrics", "MinusQuantity");
            DropColumn("dbo.Fabrics", "AddQuantity");
        }
    }
}
