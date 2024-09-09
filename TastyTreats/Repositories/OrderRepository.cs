using TastyTreats.Contexts;
using TastyTreats.Models;

namespace TastyTreats.Repositories
{
    public class OrderRepository
    {
         TastyTreatsContext context;

        //CRUD 
        public OrderRepository(TastyTreatsContext Context)
        {
            context = Context;    
        }
        public void Add( Order order)
        {
            context.Add(order);
 
        }
        public void Update(Order order) { 
            context.Update(order);
        }
        public void Delete(int id) { 
            var data=GetById(id);
            context.Orders.Remove(data);
        }
        public Order GetById(int id) {
            return context.Orders.FirstOrDefault(O => O.OrderId == id);
        }
        public List<Order> GetAll() {
            return context.Orders.ToList();
        }
        public void Save()
        {
             context.SaveChanges();
        }
    }
}
