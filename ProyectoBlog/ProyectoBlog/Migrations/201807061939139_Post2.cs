namespace ProyectoBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Post2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "CategoryName_Id", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "CategoryName_Id" });
            AddColumn("dbo.Posts", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "CategoryName", c => c.String());
            DropColumn("dbo.Posts", "CategoryName_Id");
            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Posts", "CategoryName_Id", c => c.Int());
            DropColumn("dbo.Posts", "CategoryName");
            DropColumn("dbo.Posts", "CategoryId");
            CreateIndex("dbo.Posts", "CategoryName_Id");
            AddForeignKey("dbo.Posts", "CategoryName_Id", "dbo.Categories", "Id");
        }
    }
}
