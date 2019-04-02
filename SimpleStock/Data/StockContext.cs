using Microsoft.EntityFrameworkCore;
using SimpleStock.Models;

namespace SimpleStock.Data
{
    public class StockContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        public StockContext(DbContextOptions<StockContext> options) : base(options)
        {
        }
    }
}
