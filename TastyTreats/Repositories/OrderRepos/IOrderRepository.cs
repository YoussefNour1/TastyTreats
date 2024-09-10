using TastyTreats.Models;

namespace TastyTreats.Repositories.OrderRepos
{
    public interface IOrderRepository
    {
        public void Add(Order order);

        public void Update(Order order);

        public void Delete(int? id);

        public Order GetById(int? id);

        public List<Order> GetAll();

        public void Save();

    }
}
