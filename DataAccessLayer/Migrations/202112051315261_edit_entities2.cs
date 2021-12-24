namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_entities2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Writers", "WriterImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriterImage", c => c.String(maxLength: 250));
        }
    }
}
