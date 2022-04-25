namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usermodeladded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        name = c.String(),
                        lastName = c.String(),
                        fullName = c.String(),
                        email = c.String(),
                        password = c.String(),
                        createdOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Categories", "User_id", c => c.Guid());
            CreateIndex("dbo.Categories", "User_id");
            AddForeignKey("dbo.Categories", "User_id", "dbo.Users", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "User_id", "dbo.Users");
            DropIndex("dbo.Categories", new[] { "User_id" });
            DropColumn("dbo.Categories", "User_id");
            DropTable("dbo.Users");
        }
    }
}
