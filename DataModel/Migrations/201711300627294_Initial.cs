namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sarees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Material = c.Int(nullable: false),
                        Colour = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sarees");
        }
    }
}
