namespace MyFabricStashApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReceiptsToDBSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        ReceiptId = c.Int(nullable: false, identity: true),
                        ReceiptImagePath = c.String(),
                        ReceiptDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ReceiptId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Receipts");
        }
    }
}
