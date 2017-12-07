namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        city_name = c.String(nullable: false, maxLength: 128),
                        country_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        first_name = c.String(nullable: false, maxLength: 128),
                        last_name = c.String(nullable: false, maxLength: 128),
                        company_name = c.String(maxLength: 128),
                        VAT_ID = c.String(maxLength: 64),
                        city_id = c.Int(nullable: false),
                        client_address = c.String(nullable: false, unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        country_name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Payment_data",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        payment_type_id = c.Int(nullable: false),
                        data_name = c.String(nullable: false, maxLength: 255),
                        data_type = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Payment_details",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        shipment_id = c.Int(nullable: false),
                        payment_data_id = c.Int(nullable: false),
                        value = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Payment_type",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type_name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Product_type",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type_name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        product_name = c.String(nullable: false, maxLength: 64),
                        product_description = c.String(nullable: false, maxLength: 255),
                        product_type_id = c.Int(nullable: false),
                        unit = c.String(nullable: false, maxLength: 16),
                        price_per_unit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreviewImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Images", t => t.PreviewImageId, cascadeDelete: true)
                .Index(t => t.PreviewImageId);
            
            CreateTable(
                "dbo.Shipment_details",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        shipment_id = c.Int(nullable: false),
                        product_id = c.Int(nullable: false),
                        quanitity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        price_per_unit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Shipment_status",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        shipment_id = c.Int(nullable: false),
                        status_catalog_id = c.Int(nullable: false),
                        status_time = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"),
                        notes = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Shipment_type",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type_name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Shipments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        client_id = c.Int(nullable: false),
                        time_created = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"),
                        shipment_type_id = c.Int(nullable: false),
                        payment_type_id = c.Int(nullable: false),
                        shipping_address = c.String(nullable: false, unicode: false, storeType: "text"),
                        billing_address = c.String(nullable: false, unicode: false, storeType: "text"),
                        products_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        delivery_cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        final_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Status_catalog",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        status_name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        product_id = c.Int(nullable: false, identity: true),
                        in_stock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        last_update_time = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"),
                    })
                .PrimaryKey(t => t.product_id);
            
            AddColumn("dbo.Images", "Product_id", c => c.Int());
            CreateIndex("dbo.Images", "Product_id");
            AddForeignKey("dbo.Images", "Product_id", "dbo.Products", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "PreviewImageId", "dbo.Images");
            DropForeignKey("dbo.Images", "Product_id", "dbo.Products");
            DropIndex("dbo.Products", new[] { "PreviewImageId" });
            DropIndex("dbo.Images", new[] { "Product_id" });
            DropColumn("dbo.Images", "Product_id");
            DropTable("dbo.Stocks");
            DropTable("dbo.Status_catalog");
            DropTable("dbo.Shipments");
            DropTable("dbo.Shipment_type");
            DropTable("dbo.Shipment_status");
            DropTable("dbo.Shipment_details");
            DropTable("dbo.Products");
            DropTable("dbo.Product_type");
            DropTable("dbo.Payment_type");
            DropTable("dbo.Payment_details");
            DropTable("dbo.Payment_data");
            DropTable("dbo.Countries");
            DropTable("dbo.Clients");
            DropTable("dbo.Cities");
        }
    }
}
