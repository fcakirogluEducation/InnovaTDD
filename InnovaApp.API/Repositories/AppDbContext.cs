using Microsoft.EntityFrameworkCore;

namespace InnovaApp.API.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext>? options) : DbContext(options)
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        public DbSet<User> Users { get; set; }
    }
}