namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        categoryId = c.Guid(nullable: false),
                        name = c.String(),
                        createdOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        itemId = c.Guid(nullable: false),
                        categoryId = c.Guid(nullable: false),
                        name = c.String(),
                        description = c.String(),
                        image = c.Binary(),
                        createdOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.categoryId, cascadeDelete: true)
                .Index(t => t.categoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "categoryId", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "categoryId" });
            DropTable("dbo.Items");
            DropTable("dbo.Categories");
        }
    }
}
