namespace MyFabricStashApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fabrics",
                c => new
                    {
                        FabricId = c.Int(nullable: false, identity: true),
                        MainCategory = c.String(),
                        SubCategory1 = c.String(),
                        SubCategory2 = c.String(),
                        Name = c.String(),
                        ImagePath = c.String(),
                        Location = c.String(),
                        Type = c.String(),
                        Weight = c.String(),
                        Content = c.String(),
                        Design = c.String(),
                        CurrentAmount = c.Int(nullable: false),
                        Source = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.FabricId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        FabricId = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        PurchaseAmount = c.Int(nullable: false),
                        PurchasePrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Fabrics", t => t.FabricId, cascadeDelete: true)
                .Index(t => t.FabricId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "FabricId", "dbo.Fabrics");
            DropIndex("dbo.Purchases", new[] { "FabricId" });
            DropTable("dbo.Purchases");
            DropTable("dbo.Fabrics");
        }
    }
}
