namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeaturedItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeaturedItems",
                c => new
                    {
                        Image_Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Image_Id);
            
            AddColumn("dbo.Images", "FeaturedItems_Image_Id", c => c.Int());
            CreateIndex("dbo.Images", "FeaturedItems_Image_Id");
            AddForeignKey("dbo.Images", "FeaturedItems_Image_Id", "dbo.FeaturedItems", "Image_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "FeaturedItems_Image_Id", "dbo.FeaturedItems");
            DropIndex("dbo.Images", new[] { "FeaturedItems_Image_Id" });
            DropColumn("dbo.Images", "FeaturedItems_Image_Id");
            DropTable("dbo.FeaturedItems");
        }
    }
}
