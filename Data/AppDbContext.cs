using Microsoft.EntityFrameworkCore;
using ProductApi_Task.Models;

namespace ProductApi_Task.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet properties for your models
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding data for Users
            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, UserName = "user1", Email = "user1@example.com" },
                new User { UserID = 2, UserName = "user2", Email = "user2@example.com" }
            );

            // Seeding data for Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, ProductName = "Product 1", Price = 10.00m },
                new Product { ProductID = 2, ProductName = "Product 2", Price = 20.00m }
            );

            // Seeding data for Carts
            modelBuilder.Entity<Cart>().HasData(
                new Cart { CartID = 1, UserID = 1, ProductID = 1, Quantity = 2 },
                new Cart { CartID = 2, UserID = 2, ProductID = 2, Quantity = 1 }
            );

            // Seeding data for Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, UserID = 1, Total_Amount = 20.00m },
                new Order { OrderId = 2, UserID = 2, Total_Amount = 20.00m }
            );
        }
    }
}
