using Catalog.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.DataContext
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

    }
}
