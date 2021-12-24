namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_entity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WriterImages", "WriterID", "dbo.Writers");
            DropIndex("dbo.WriterImages", new[] { "WriterID" });
            AddColumn("dbo.Writers", "WriterImage", c => c.String(maxLength: 250));
            DropTable("dbo.WriterImages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WriterImages",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 100),
                        ImagePath = c.String(maxLength: 200),
                        WriterID = c.Int(),
                    })
                .PrimaryKey(t => t.ImageID);
            
            DropColumn("dbo.Writers", "WriterImage");
            CreateIndex("dbo.WriterImages", "WriterID");
            AddForeignKey("dbo.WriterImages", "WriterID", "dbo.Writers", "WriterID");
        }
    }
}
