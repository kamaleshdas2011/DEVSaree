namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newprod : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "Product_id", "dbo.Products");
            DropIndex("dbo.Images", new[] { "Product_id" });
            DropColumn("dbo.Images", "Product_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "Product_id", c => c.Int());
            CreateIndex("dbo.Images", "Product_id");
            AddForeignKey("dbo.Images", "Product_id", "dbo.Products", "id");
        }
    }
}
