namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedrequiredvalidationtosomecolumns : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Items", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "password", c => c.String());
            AlterColumn("dbo.Users", "email", c => c.String());
            AlterColumn("dbo.Users", "name", c => c.String());
            AlterColumn("dbo.Items", "name", c => c.String());
            AlterColumn("dbo.Categories", "name", c => c.String());
        }
    }
}
