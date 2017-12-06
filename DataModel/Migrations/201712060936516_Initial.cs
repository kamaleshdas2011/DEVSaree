namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeaturedItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageId = c.Int(nullable: false),
                        FeaturedImage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.FeaturedImage_Id)
                .Index(t => t.FeaturedImage_Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUri = c.String(),
                        Name = c.String(),
                        BaseColour = c.String(),
                        Caption = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sarees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterialId = c.Int(nullable: false),
                        ColourId = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colours", t => t.ColourId, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .Index(t => t.MaterialId)
                .Index(t => t.ColourId)
                .Index(t => t.ImageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sarees", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Sarees", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Sarees", "ColourId", "dbo.Colours");
            DropForeignKey("dbo.FeaturedItems", "FeaturedImage_Id", "dbo.Images");
            DropIndex("dbo.Sarees", new[] { "ImageId" });
            DropIndex("dbo.Sarees", new[] { "ColourId" });
            DropIndex("dbo.Sarees", new[] { "MaterialId" });
            DropIndex("dbo.FeaturedItems", new[] { "FeaturedImage_Id" });
            DropTable("dbo.Sarees");
            DropTable("dbo.Materials");
            DropTable("dbo.Images");
            DropTable("dbo.FeaturedItems");
            DropTable("dbo.Colours");
        }
    }
}
