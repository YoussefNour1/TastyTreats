using TastyTreats.Models;

namespace TastyTreats.Contexts.DummyData
{
    public class DummyCartContext
    {
        public static List<Cart> GetCarts()
        {
            return new List<Cart>
            {
                new Cart
                {
                    CartId = 1,
                    Quantity = 2,
                    UserId = 1
                },
                new Cart
                {
                    CartId = 2,
                    Quantity = 3,
                    UserId = 2
                }
            };
        }
    }
}
