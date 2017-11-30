namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImage1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "ImageUri", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "ImageUri");
        }
    }
}
