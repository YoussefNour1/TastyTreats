using Microsoft.EntityFrameworkCore;
using TastyTreats.Contexts;
using TastyTreats.Models;

namespace TastyTreats.Repositories.OrderRepos
{
    public class OrderRepository:IOrderRepository
    {
        TastyTreatsContext context;

        //CRUD 
        public OrderRepository(TastyTreatsContext Context)
        {
            context = Context;
        }



        public void Add(Order order)
        {
            context.Add(order);

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

        public List<Order> GetAll()
        {
            return context.Orders.Include(o=>o.OrderItems).Include(u=>u.User).ToList();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
