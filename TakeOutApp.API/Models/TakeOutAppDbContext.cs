using Microsoft.EntityFrameworkCore;

namespace TakeOutApp.API.Models
{
    public class TakeOutAppDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public DbSet<MenuItem> MenuItems { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;

        public TakeOutAppDbContext(DbContextOptions<TakeOutAppDbContext> options) : base(options)
        {
        }
    }
}
