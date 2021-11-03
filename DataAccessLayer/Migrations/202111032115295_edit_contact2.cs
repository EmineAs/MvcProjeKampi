namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_contact2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contacts", "UserPhone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "UserPhone", c => c.String(maxLength: 50));
        }
    }
}
