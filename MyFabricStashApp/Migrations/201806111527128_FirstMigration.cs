namespace MyFabricStashApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fabrics",
                c => new
                    {
                        FabricId = c.Int(nullable: false, identity: true),
                        MainCategoryId = c.Int(nullable: false),
                        SubCategory1Id = c.Int(nullable: false),
                        Name = c.String(),
                        ImagePath = c.String(),
                        Location = c.String(),
                        Type = c.String(),
                        Weight = c.String(),
                        Content = c.String(),
                        Design = c.String(),
                        Brand = c.String(),
                        Quantity = c.Double(nullable: false),
                        Width = c.Int(nullable: false),
                        Source = c.String(),
                        Notes = c.String(),
                        ItemsSold = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FabricId)
                .ForeignKey("dbo.MainCategories", t => t.MainCategoryId, cascadeDelete: false)
                .ForeignKey("dbo.SubCategory1", t => t.SubCategory1Id, cascadeDelete: false)
                .Index(t => t.MainCategoryId)
                .Index(t => t.SubCategory1Id);
            
            CreateTable(
                "dbo.MainCategories",
                c => new
                    {
                        MainCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MainCategoryId);
            
            CreateTable(
                "dbo.SubCategory1",
                c => new
                    {
                        SubCategory1Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MainCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubCategory1Id)
                .ForeignKey("dbo.MainCategories", t => t.MainCategoryId, cascadeDelete: false)
                .Index(t => t.MainCategoryId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(nullable: false),
                        PurchaseQuantity = c.Int(nullable: false),
                        PurchasePrice = c.Double(nullable: false),
                        FabricId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Fabrics", t => t.FabricId, cascadeDelete: false)
                .Index(t => t.FabricId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fabrics", "SubCategory1Id", "dbo.SubCategory1");
            DropForeignKey("dbo.Purchases", "FabricId", "dbo.Fabrics");
            DropForeignKey("dbo.Fabrics", "MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.SubCategory1", "MainCategoryId", "dbo.MainCategories");
            DropIndex("dbo.Purchases", new[] { "FabricId" });
            DropIndex("dbo.SubCategory1", new[] { "MainCategoryId" });
            DropIndex("dbo.Fabrics", new[] { "SubCategory1Id" });
            DropIndex("dbo.Fabrics", new[] { "MainCategoryId" });
            DropTable("dbo.Purchases");
            DropTable("dbo.SubCategory1");
            DropTable("dbo.MainCategories");
            DropTable("dbo.Fabrics");
        }
    }
}
