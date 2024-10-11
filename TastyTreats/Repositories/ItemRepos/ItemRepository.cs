using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TastyTreats.Contexts;
using TastyTreats.Models;

namespace TastyTreats.Repositories.ItemRepos
{
    public class ItemRepository : IItemRepository
    {
        TastyTreatsContext context;

        public ItemRepository(TastyTreatsContext _context)
        {
            context = _context;
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

        //public List<Item> GetAll()
        //{
        //    var ItemList = context.Items.Include(i => i.Category)
        //        .Select(i => new Item 
        //        {
        //            ItemId = i.ItemId,
        //            Name = i.Name,
        //            Price=i.Price,
        //            Discount=i.Discount,

        //            Description = i.Description,
        //            ItemPicture = i.ItemPicture,
        //            Category = i.Category,
        //            Availability = i.Availability
        //        }).ToList();
        //    foreach (var item in ItemList)
        //    {
        //        item.Category.Name = context.Categories
        //            .FirstOrDefault(c => c.CategoryId == item.Category.CategoryId)?.Name;
        //    }

        //    return ItemList;
        //}


        //public List<Item> GetAll(int pageNumber, int pageSize)
        //{
        //    var ItemList = context.Items.Include(i => i.Category)
        //        .Select(i => new Item
        //        {
        //            ItemId = i.ItemId,
        //            Name = i.Name,
        //            Price = i.Price,
        //            Discount = i.Discount,
        //            Description = i.Description,
        //            ItemPicture = i.ItemPicture,
        //            Category = i.Category,
        //            Availability = i.Availability
        //        })
        //        .Skip((pageNumber - 1) * pageSize) // Skip items based on the page number
        //        .Take(pageSize)                    // Take only the number of items for the page
        //        .ToList();

        //    foreach (var item in ItemList)
        //    {
        //        item.Category.Name = context.Categories
        //            .FirstOrDefault(c => c.CategoryId == item.Category.CategoryId)?.Name;
        //    }

        //    return ItemList;
        //}



        public void Save()
        {
            context.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return context.Categories.ToList();
        }

        public int CountItems()
        {
            return context.Items.Count();
        }

        public List<Item> GetAll(int pageNumber, int pageSize, string searchTerm)
        {
            // Check if the searchTerm is "All" to get all items
            var itemList = context.Items.Include(i => i.Category)
                .Where(item => string.IsNullOrEmpty(searchTerm) || searchTerm == "All" ||
                               item.Category.Name.Contains(searchTerm)) // Filter for category name
                .Select(i => new Item
                {
                    ItemId = i.ItemId,
                    Name = i.Name,
                    Price = i.Price,
                    Discount = i.Discount,
                    Description = i.Description,
                    ItemPicture = i.ItemPicture,
                    Category = i.Category,
                    Availability = i.Availability
                })
                .Skip((pageNumber - 1) * pageSize) // Skip items based on the page number
                .Take(pageSize)                    // Take only the number of items for the page
                .ToList();

            return itemList;
        }


        public int CountItems(string searchTerm)
        {
            // Check if the searchTerm is "All" to count all items
            return context.Items.Include(i => i.Category)
                .Count(item => string.IsNullOrEmpty(searchTerm) || searchTerm == "All" ||
                               item.Category.Name.Contains(searchTerm));
        }


    }
}
