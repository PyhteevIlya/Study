using Microsoft.EntityFrameworkCore;
using ProductCatalogData.Models;

namespace Product_catalog_with_categories_WebAPI.Data
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<Electronic> Electronics { get; set; }
        public DbSet<Computer> Computers { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options): base(options)
        {

        }
    }
}
