using Microsoft.EntityFrameworkCore;
using TastyTreats.Models;

namespace TastyTreats.Contexts
{
    public class TastyTreatsContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=LUCIFER\\MSSQLSERVER01; Database=TastyTreatsDB; Integrated Security=True; MultipleActiveResultSets=true; TrustServerCertificate=True;");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>();

            // Further configurations if needed
        }
    }
}
