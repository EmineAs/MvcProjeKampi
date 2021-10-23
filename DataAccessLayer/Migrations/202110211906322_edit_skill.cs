namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_skill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Admin_AdminID", c => c.Int());
            AddColumn("dbo.Skills", "AdminID", c => c.Int());
            CreateIndex("dbo.Admins", "Admin_AdminID");
            CreateIndex("dbo.Skills", "AdminID");
            AddForeignKey("dbo.Admins", "Admin_AdminID", "dbo.Admins", "AdminID");
            AddForeignKey("dbo.Skills", "AdminID", "dbo.Admins", "AdminID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "AdminID", "dbo.Admins");
            DropForeignKey("dbo.Admins", "Admin_AdminID", "dbo.Admins");
            DropIndex("dbo.Skills", new[] { "AdminID" });
            DropIndex("dbo.Admins", new[] { "Admin_AdminID" });
            DropColumn("dbo.Skills", "AdminID");
            DropColumn("dbo.Admins", "Admin_AdminID");
        }
    }
}
