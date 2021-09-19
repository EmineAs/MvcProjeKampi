namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_readinmessage2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "Read", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "Read", c => c.Boolean(nullable: false));
        }
    }
}
