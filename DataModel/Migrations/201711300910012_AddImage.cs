namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Sarees", "Image_Id", c => c.Int());
            CreateIndex("dbo.Sarees", "Image_Id");
            AddForeignKey("dbo.Sarees", "Image_Id", "dbo.Images", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sarees", "Image_Id", "dbo.Images");
            DropIndex("dbo.Sarees", new[] { "Image_Id" });
            DropColumn("dbo.Sarees", "Image_Id");
            DropTable("dbo.Images");
        }
    }
}
