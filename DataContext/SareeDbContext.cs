using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext
{
    public class SareeDbContext: DbContext
    {
        public SareeDbContext()
        : base("name=DefaultConnection")
        {
        }
        public DbSet<Sarees> SareeContext { get; set; }
    }
}
