namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_admin21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Admins", "WriterStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "WriterStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Admins", "AdminStatus");
        }
    }
}
