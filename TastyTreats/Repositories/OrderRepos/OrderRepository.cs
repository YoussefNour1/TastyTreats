using Microsoft.EntityFrameworkCore;
using TastyTreats.Contexts;
using TastyTreats.Models;

namespace TastyTreats.Repositories.OrderRepos
{
    public class OrderRepository : IOrderRepository
    {
        TastyTreatsContext context;

        //CRUD 
        public OrderRepository(TastyTreatsContext Context)
        {
            context = Context;
        }



        public async Task<Order>  Add(int UserId)
        {
            var cart = await context.Carts
            .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Item)
            .FirstOrDefaultAsync(c => c.UserId == UserId);
            if (cart == null || !cart.CartItems.Any())
            {
                throw new InvalidOperationException("Cart is empty or does not exist.");
            }
            decimal totalPrice = cart.CartItems.Sum(ci => ci.Quantity * ci.Item.FinalPrice);
            var order = new Order
            {
                UserId = UserId,
                OrderStatus = "Pending",
                TotalPrice = totalPrice,
                CreatedAt = DateTime.UtcNow,
                OrderItems = cart.CartItems.Select(ci => new OrderItem
                {
                    ItemId = ci.ItemId,
                    Quantity = ci.Quantity,
                    CreatedAt = DateTime.UtcNow
                }).ToList()
            };
            await context.Orders.AddAsync(order);
            context.CartItems.RemoveRange(cart.CartItems);
            await context.SaveChangesAsync();
            return order;

        }
        public void Update(Order order)
        {
            context.Update(order);
        }
        public void Delete(int? id)
        {
            var data = GetById(id);
            context.Orders.Remove(data);
        }
        public Order GetById(int? id)
        {
 
            return context.Orders.
                Include(u=>u.User).
                FirstOrDefault(O => O.OrderId == id);
        }
        public Order Details(int? id)
        {
            return context.Orders.
                Include(o => o.OrderItems).
                ThenInclude(io => io.Item).
                Include(u => u.User).
                FirstOrDefault(O => O.OrderId == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return context.Orders.Include(o=>o.OrderItems).Include(u=>u.User).ToList();
        }
        public async Task Save()
        {
           await context.SaveChangesAsync();
        }
        public async Task<List<Order>> GetOrdersByUserId(int userId)
        {
            return await context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }
    }
}
