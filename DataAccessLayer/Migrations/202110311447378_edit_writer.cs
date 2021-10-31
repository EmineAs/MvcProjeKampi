namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_writer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterPassWord", c => c.String(maxLength: 200));
            DropColumn("dbo.Writers", "WritePassWord");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WritePassWord", c => c.String(maxLength: 200));
            DropColumn("dbo.Writers", "WriterPassWord");
        }
    }
}
