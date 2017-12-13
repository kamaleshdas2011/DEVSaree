namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "all_image_ids", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "all_image_ids");
        }
    }
}
