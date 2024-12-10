using E_Commerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Shipping> Shipping { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    
}