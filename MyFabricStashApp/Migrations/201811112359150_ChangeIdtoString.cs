namespace MyFabricStashApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIdtoString : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Purchases", "FabricId", "dbo.Fabrics");
            DropIndex("dbo.Purchases", new[] { "FabricId" });
            DropPrimaryKey("dbo.Fabrics");
            AddColumn("dbo.Purchases", "Fabric_FabricId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Fabrics", "FabricId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Fabrics", "FabricId");
            CreateIndex("dbo.Purchases", "Fabric_FabricId");
            AddForeignKey("dbo.Purchases", "Fabric_FabricId", "dbo.Fabrics", "FabricId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "Fabric_FabricId", "dbo.Fabrics");
            DropIndex("dbo.Purchases", new[] { "Fabric_FabricId" });
            DropPrimaryKey("dbo.Fabrics");
            AlterColumn("dbo.Fabrics", "FabricId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Purchases", "Fabric_FabricId");
            AddPrimaryKey("dbo.Fabrics", "FabricId");
            CreateIndex("dbo.Purchases", "FabricId");
            AddForeignKey("dbo.Purchases", "FabricId", "dbo.Fabrics", "FabricId", cascadeDelete: true);
        }
    }
}
