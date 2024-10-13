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
                    CategoryId = 1 // Beverages
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
                    CategoryId = 2 // Snacks
                },
                new Item
                {
                    ItemId = 3,
                    Name = "Mozzarella Stick",
                    ItemPicture = "/img/mozzarella_d1a8f62f-31ca-4c48-936f-1077b8a6c6fe.jpg",
                    Price = 8.00m,
                    Discount = 0.30m,
                    Description = "Lorem, deren, trataro, filede, nerada.",
                    Availability = false,
                    CategoryId = 2 // Snacks
                },
                new Item
                {
                    ItemId = 4,
                    Name = "Cake",
                    ItemPicture = "/img/cake_c69bec60-aca2-472c-8a9c-e4365167d909.jpg",
                    Price = 9.00m,
                    Discount = 0.30m,
                    Description = "A delicate crab cake served on a toasted roll with lettuce and tartar sauce.",
                    Availability = true,
                    CategoryId = 1 // Beverages or Deserts
                },
                new Item
                {
                    ItemId = 5,
                    Name = "Tuscan Grilled",
                    ItemPicture = "/img/tuscan-grilled_92567c02-132a-40c8-a31d-4d0a9a6012ed.jpg",
                    Price = 7.50m,
                    Discount = 0.10m,
                    Description = "Grilled chicken with provolone, artichoke hearts, and roasted red pesto.",
                    Availability = true,
                    CategoryId = 2 // Snacks
                },
                new Item
                {
                    ItemId = 6,
                    Name = "Lobster Bisque",
                    ItemPicture = "/img/-bisque_944a569a-f338-43bc-bce4-bd87930ba6b3.jpg",
                    Price = 5.95m,
                    Discount = 0.50m,
                    Description = "A rich and creamy soup made from lobster shells, butter, cream, and aromatic herbs.",
                    Availability = true,
                    CategoryId = 4 // Soup
                },
                new Item
                {
                    ItemId = 7,
                    Name = "Bread Barrel",
                    ItemPicture = "/img/bread-barrel_f59cfba4-d6e0-45dd-8121-660ee0494f3a.jpg",
                    Price = 6.59m,
                    Discount = 0.00m,
                    Description = "A rustic, round loaf of bread baked in a cylindrical shape.",
                    Availability = true,
                    CategoryId = 5 // Bread
                },
                new Item
                {
                    ItemId = 8,
                    Name = "Caesar Selections",
                    ItemPicture = "/img/caesar_cbd4d8eb-7b09-4919-96b5-b383f55b365a.jpg",
                    Price = 8.95m,
                    Discount = 0.10m,
                    Description = "Crisp romaine lettuce, Caesar dressing, croutons, Parmesan cheese, and toppings.",
                    Availability = false,
                    CategoryId = 6 // Salad
                },
                new Item
                {
                    ItemId = 9,
                    Name = "Greek Salad",
                    ItemPicture = "/img/greek-salad_9468cfd8-7d81-4c25-a098-7421f5db66d5.jpg",
                    Price = 9.95m,
                    Discount = 0.00m,
                    Description = "Fresh spinach, romaine, tomatoes, and Greek olives.",
                    Availability = true,
                    CategoryId = 6 // Salad
                },
                new Item
                {
                    ItemId = 10,
                    Name = "Spinach Salad",
                    ItemPicture = "/img/spinach-salad_fb2d649d-77ea-4307-b009-a81801f99c3e.jpg",
                    Price = 9.95m,
                    Discount = 0.25m,
                    Description = "Fresh spinach with mushrooms, hard-boiled egg, and warm bacon vinaigrette.",
                    Availability = true,
                    CategoryId = 6 // Salad
                },
                new Item
                {
                    ItemId = 11,
                    Name = "Lobster Roll",
                    ItemPicture = "/img/lobster-roll_f903779d-4a00-4e5a-9243-51776bc47f23.jpg",
                    Price = 12.95m,
                    Discount = 0.30m,
                    Description = "Plump lobster meat, mayo, and crisp lettuce on a toasted bulky roll.",
                    Availability = true,
                    CategoryId = 7 // Sandwich
                }
            };
        }
    }
}
