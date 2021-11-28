namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_skill : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Skills", "AdminID", "dbo.Admins");
            DropIndex("dbo.Skills", new[] { "AdminID" });
            DropColumn("dbo.Skills", "AdminID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "AdminID", c => c.Int());
            CreateIndex("dbo.Skills", "AdminID");
            AddForeignKey("dbo.Skills", "AdminID", "dbo.Admins", "AdminID");
        }
    }
}
