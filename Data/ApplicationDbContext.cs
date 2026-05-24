using Microsoft.EntityFrameworkCore;
using CrudApp.Models;

namespace CrudApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial data
            modelBuilder.Entity<Product>().HasData(
                new Product 
                { 
                    Id = 1, 
                    Name = "Laptop", 
                    Description = "High-performance laptop", 
                    Price = 999.99m, 
                    Quantity = 5,
                    CreatedDate = DateTime.Now
                },
                new Product 
                { 
                    Id = 2, 
                    Name = "Mouse", 
                    Description = "Wireless mouse", 
                    Price = 29.99m, 
                    Quantity = 50,
                    CreatedDate = DateTime.Now
                },
                new Product 
                { 
                    Id = 3, 
                    Name = "Keyboard", 
                    Description = "Mechanical keyboard", 
                    Price = 79.99m, 
                    Quantity = 30,
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
