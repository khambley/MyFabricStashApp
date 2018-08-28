namespace MyFabricStashApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImagePath2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fabrics", "ImagePath2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fabrics", "ImagePath2");
        }
    }
}
