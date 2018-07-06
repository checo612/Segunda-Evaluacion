namespace ProyectoBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Post1 : DbMigration
    {
        public override void Up()
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
            CreateIndex("dbo.Posts", "CategoryName_Id");
            AddForeignKey("dbo.Posts", "CategoryName_Id", "dbo.Categories", "Id");
            DropColumn("dbo.Posts", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "CategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Posts", "CategoryName_Id", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "CategoryName_Id" });
            DropColumn("dbo.Posts", "CategoryName_Id");
            DropTable("dbo.Categories");
        }
    }
}
