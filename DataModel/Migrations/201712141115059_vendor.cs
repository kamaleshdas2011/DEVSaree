namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vendor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Categoty", c => c.String());
            AddColumn("dbo.Products", "all_vendors", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "all_vendors");
            DropColumn("dbo.Images", "Categoty");
        }
    }
}
