using System.Data.Entity;

namespace DataModel
{
    public class SareeDbContext : DbContext
    {
        public SareeDbContext()
        : base("name=DefaultConnection")
        {
        }
        public DbSet<Sarees> SareeContext { get; set; }
        public DbSet<Images> ImageContext { get; set; }
        public DbSet<FeaturedItems> FeaturedItems { get; set; }

    }
}
