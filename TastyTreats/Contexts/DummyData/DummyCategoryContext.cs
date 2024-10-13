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
                },
                new Category
                {
                    CategoryId = 3,
                    Name = "Deserts",
                    Description = "Various types of Deserts."
                },
                new Category
                {
                    CategoryId = 4,
                    Name = "Soup",
                    Description = "Soup is a liquid-based dish, often savory."
                },
                new Category
                {
                    CategoryId = 5,
                    Name = "Bread",
                    Description = "A staple food made from dough, typically baked."
                },
                new Category
                {
                    CategoryId = 6,
                    Name = "Salad",
                    Description = "A dish made primarily from raw or cooked vegetables."
                },
                new Category
                {
                    CategoryId = 7,
                    Name = "Sandwich",
                    Description = "A versatile dish consisting of bread with fillings."
                }
            };
        }
    }
}
