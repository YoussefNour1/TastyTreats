using TastyTreats.Contexts;
using TastyTreats.Models;

namespace TastyTreats.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        
        TastyTreatsContext context;
        public CategoryRepository(TastyTreatsContext Context)
        {
            context = Context;
        }
        public void Add(Category category)
        {
            context.Add(category);
        }
        public void Update(Category category)
        {
            context.Update(category);
        }
        public void Delete(int id)
        {
            var catg = GetById(id);
            if(catg != null)
            {
                context.Remove(catg);
            }
           
        }
        public Category GetById(int id)
        {
            return context.Categories.FirstOrDefault(c=>c.CategoryId==id);
        }
        public List<Category> GetAll()
        {
            return context.Categories.ToList();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
