namespace MyFabricStashApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSourceToCreateFabric : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fabrics", "Source", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fabrics", "Source");
        }
    }
}
