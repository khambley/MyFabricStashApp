namespace MyFabricStashApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSourceModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "SourceId", c => c.Int(nullable: false));
            AddColumn("dbo.Purchases", "Notes", c => c.String());
            DropColumn("dbo.Fabrics", "Source");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fabrics", "Source", c => c.String());
            DropColumn("dbo.Purchases", "Notes");
            DropColumn("dbo.Purchases", "SourceId");
        }
    }
}
