namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagelist : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "PreviewImages_Id", "dbo.Images");
            DropIndex("dbo.Products", new[] { "PreviewImages_Id" });
            DropColumn("dbo.Products", "PreviewImageId");
            RenameColumn(table: "dbo.Products", name: "PreviewImages_Id", newName: "PreviewImageId");
            AlterColumn("dbo.Products", "PreviewImageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "PreviewImageId");
            AddForeignKey("dbo.Products", "PreviewImageId", "dbo.Images", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "PreviewImageId", "dbo.Images");
            DropIndex("dbo.Products", new[] { "PreviewImageId" });
            AlterColumn("dbo.Products", "PreviewImageId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "PreviewImageId", newName: "PreviewImages_Id");
            AddColumn("dbo.Products", "PreviewImageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "PreviewImages_Id");
            AddForeignKey("dbo.Products", "PreviewImages_Id", "dbo.Images", "Id");
        }
    }
}
