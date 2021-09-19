namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_admin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminPassword", c => c.String());
            DropColumn("dbo.Admins", "AdminPasswordHash");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminPasswordHash", c => c.String());
            DropColumn("dbo.Admins", "AdminPassword");
        }
    }
}
