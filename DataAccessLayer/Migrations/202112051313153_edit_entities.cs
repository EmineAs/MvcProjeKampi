namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_entities : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.ImageID)
                .ForeignKey("dbo.Writers", t => t.WriterID)
                .Index(t => t.WriterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WriterImages", "WriterID", "dbo.Writers");
            DropIndex("dbo.WriterImages", new[] { "WriterID" });
            DropTable("dbo.WriterImages");
        }
    }
}
