namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeaturedItems : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "FeaturedItems_Image_Id", "dbo.FeaturedItems");
            DropIndex("dbo.Images", new[] { "FeaturedItems_Image_Id" });
            AddColumn("dbo.FeaturedItems", "FeaturedImage_Id", c => c.Int());
            CreateIndex("dbo.FeaturedItems", "FeaturedImage_Id");
            AddForeignKey("dbo.FeaturedItems", "FeaturedImage_Id", "dbo.Images", "Id");
            DropColumn("dbo.Images", "FeaturedItems_Image_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "FeaturedItems_Image_Id", c => c.Int());
            DropForeignKey("dbo.FeaturedItems", "FeaturedImage_Id", "dbo.Images");
            DropIndex("dbo.FeaturedItems", new[] { "FeaturedImage_Id" });
            DropColumn("dbo.FeaturedItems", "FeaturedImage_Id");
            CreateIndex("dbo.Images", "FeaturedItems_Image_Id");
            AddForeignKey("dbo.Images", "FeaturedItems_Image_Id", "dbo.FeaturedItems", "Image_Id");
        }
    }
}
