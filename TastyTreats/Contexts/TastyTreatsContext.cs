using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TastyTreats.Contexts.DummyData;
using TastyTreats.Models;
using TastyTreats.ViewModel;

namespace TastyTreats.Contexts
{
    public class TastyTreatsContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public TastyTreatsContext(DbContextOptions<TastyTreatsContext> options) : base(options)
        {
        }

        public TastyTreatsContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<Item>()
                .HasMany(m => m.OrderItems)
                .WithOne(oi => oi.Item)
                .HasForeignKey(oi => oi.ItemId);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.UserId);

            modelBuilder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId);

            modelBuilder.Entity<Item>()
                .HasMany(m => m.CartItems)
                .WithOne(ci => ci.Item)
                .HasForeignKey(ci => ci.ItemId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Items)
                .WithOne(i => i.Category)
                .HasForeignKey(i => i.CategoryId);

            //// Dummy Data 
            modelBuilder.Entity<User>().HasData(DummyUserContext.GetUsers().ToArray());
            modelBuilder.Entity<Category>().HasData(DummyCategoryContext.GetCategories().ToArray());
            modelBuilder.Entity<Item>().HasData(DummyItemContext.GetItems().ToArray());
            modelBuilder.Entity<Cart>().HasData(DummyCartContext.GetCarts().ToArray());

            modelBuilder.Entity<CartItem>().HasData(DummyCartItemContext.GetCartItems().ToArray());
            modelBuilder.Entity<Order>().HasData(DummyOrderContext.GetOrders().ToArray());
            modelBuilder.Entity<OrderItem>().HasData(DummyOrderItemContext.GetOrderItems().ToArray());
        }
        public DbSet<TastyTreats.ViewModel.AddRoleViewModel> AddRoleViewModel { get; set; } = default!;
    }
}
