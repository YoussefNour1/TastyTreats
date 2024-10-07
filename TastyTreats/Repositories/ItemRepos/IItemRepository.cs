using TastyTreats.Models;

namespace TastyTreats.Repositories.ItemRepos
{
    public interface IItemRepository
    {
        
        public void Add(Item item);
        public void Update(Item item);
        public void Delete(int id);
        public Item GetById(int id);
        public List<Item> GetAll();
        public IEnumerable<Category> GetCategories();
        public void Save();
    }
}
