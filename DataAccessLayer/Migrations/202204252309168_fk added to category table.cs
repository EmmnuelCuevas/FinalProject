namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkaddedtocategorytable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "User_id", "dbo.Users");
            DropIndex("dbo.Categories", new[] { "User_id" });
            RenameColumn(table: "dbo.Categories", name: "User_id", newName: "userId");
            AlterColumn("dbo.Categories", "userId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Categories", "userId");
            AddForeignKey("dbo.Categories", "userId", "dbo.Users", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "userId", "dbo.Users");
            DropIndex("dbo.Categories", new[] { "userId" });
            AlterColumn("dbo.Categories", "userId", c => c.Guid());
            RenameColumn(table: "dbo.Categories", name: "userId", newName: "User_id");
            CreateIndex("dbo.Categories", "User_id");
            AddForeignKey("dbo.Categories", "User_id", "dbo.Users", "id");
        }
    }
}
