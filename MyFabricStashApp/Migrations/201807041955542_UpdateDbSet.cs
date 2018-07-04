namespace MyFabricStashApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDbSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sources",
                c => new
                    {
                        SourceId = c.Int(nullable: false, identity: true),
                        SourceName = c.String(),
                        SourceAddress = c.String(),
                        SourceCity = c.String(),
                        SourceState = c.String(),
                        SourceZipCode = c.String(),
                        SourcePhone = c.String(),
                        SourceUrl = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.SourceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sources");
        }
    }
}
