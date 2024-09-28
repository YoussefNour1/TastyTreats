using TastyTreats.Models;

namespace TastyTreats.Contexts.DummyData
{
    public class DummyItemContext
    {
        public static List<Item> GetItems()
        {
            return new List<Item>
            {
                new Item
                {
                    ItemId = 1,
                    Name = "Coke",
                    ItemPicture = "coke.png",
                    Price = 1.99m,
                    Discount = 0.50m,
                    Description = "Refreshing cola drink.",
                    Availability = true,
                    CategoryId = 1
                },
                new Item
                {
                    ItemId = 2,
                    Name = "Chips",
                    ItemPicture = "chips.png",
                    Price = 2.49m,
                    Discount = null,
                    Description = "Crunchy potato chips.",
                    Availability = true,
                    CategoryId = 2
                }
            };
        }
    }
}
