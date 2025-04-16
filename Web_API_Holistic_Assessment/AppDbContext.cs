using Microsoft.EntityFrameworkCore;
using Web_API_Holistic_Assessment.Models;

namespace Web_API_Holistic_Assessment
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>option) : base(option)
        {
            
        }
        public DbSet<Customer>Customers { get; set; }
        public DbSet<Product>Products { get; set; }
        public DbSet<Order>Orders { get; set; }
        public DbSet<ShoppingCart>ShoppingCarts { get; set; }
    }
}
