namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_admin1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Admins", "Admin_AdminID", "dbo.Admins");
            DropIndex("dbo.Admins", new[] { "Admin_AdminID" });
            DropColumn("dbo.Admins", "Admin_AdminID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Admin_AdminID", c => c.Int());
            CreateIndex("dbo.Admins", "Admin_AdminID");
            AddForeignKey("dbo.Admins", "Admin_AdminID", "dbo.Admins", "AdminID");
        }
    }
}
