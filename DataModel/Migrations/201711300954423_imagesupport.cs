namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagesupport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "BaseColour", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "BaseColour");
        }
    }
}
