namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Images", "Categoty", c => c.String());
            AddColumn("dbo.Products", "all_vendors", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "all_vendors");
            DropColumn("dbo.Images", "Categoty");
            DropTable("dbo.Vendors");
        }
    }
}
