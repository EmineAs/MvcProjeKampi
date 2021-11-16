namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_admin2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "WriterStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "WriterStatus");
        }
    }
}
