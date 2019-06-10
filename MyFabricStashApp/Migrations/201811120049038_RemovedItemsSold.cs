namespace MyFabricStashApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedItemsSold : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fabrics", "ItemNumber", c => c.String());
            DropColumn("dbo.Fabrics", "ItemsSold");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fabrics", "ItemsSold", c => c.Int(nullable: false));
            DropColumn("dbo.Fabrics", "ItemNumber");
        }
    }
}
