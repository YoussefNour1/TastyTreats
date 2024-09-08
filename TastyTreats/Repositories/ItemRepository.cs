using TastyTreats.Contexts;
using TastyTreats.Models;

namespace TastyTreats.Repositories
{
    public class ItemRepository : IItemRepository
    {
        TastyTreatsContext context;

        public ItemRepository()
        {
            context=new TastyTreatsContext();  
        }

     
        // CRUD 

        public void Add(Item item)
        {
            context.Items.Add(item);
        }

        public void Update(Item item)
        {
            context.Items.Update(item); 
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                context.Items.Remove(item);
            }
        }

        public Item GetById(int id)
        {
            return context.Items.FirstOrDefault(i => i.ItemId == id);
        }

        public List<Item> GetAll()
        {
            return context.Items.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
