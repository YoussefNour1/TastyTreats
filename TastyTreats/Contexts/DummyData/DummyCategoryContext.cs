using TastyTreats.Models;

namespace TastyTreats.Contexts.DummyData
{
    public class DummyCategoryContext
    {
        public static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    CategoryId = 1,
                    Name = "Beverages",
                    Description = "Various types of drinks."
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Snacks",
                    Description = "Tasty snacks and munchies."
                }
            };
        }
    }
}
