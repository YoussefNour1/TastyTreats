using TastyTreats.Models;

namespace TastyTreats.Repositories.OrderRepos
{
    public interface IOrderRepository
    {
        public  Task<Order>  Add(int UserId);

        public void Update(Order order);

        public void Delete(int? id);

        public Order GetById(int? id);
        public Order Details(int? id);

        public List<Order> GetAll();

        public  Task  Save();

    }
}
