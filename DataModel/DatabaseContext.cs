using System.Data.Entity;

namespace DataModel
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        : base("name=DefaultConnection")
        {
        }
        public DbSet<Sarees> SareeContext { get; set; }
        public DbSet<Images> Image { get; set; }
        public DbSet<FeaturedItems> FeaturedItems { get; set; }
        public DbSet<Colours> Colours { get; set; }
        public DbSet<Material> Material { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Payment_data> Payment_data { get; set; }
        public DbSet<Payment_details> Payment_details { get; set; }
        public DbSet<Payment_type> Payment_type { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_type> Product_type { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Shipment_details> Shipment_details { get; set; }
        public DbSet<Shipment_status> Shipment_status { get; set; }
        public DbSet<Shipment_type> Shipment_type { get; set; }
        public DbSet<Status_catalog> Status_catalog { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
    }
}
