using TastyTreats.Models;

namespace TastyTreats.Contexts.DummyData
{
    public class DummyOrderContext
    {
        public static List<Order> GetOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    OrderId = 1,
                    OrderStatus = "Completed",
                    TotalPrice = 5.97m,
                    CreatedAt = DateTime.Now,
                    UserId = 1
                },
                new Order
                {
                    OrderId = 2,
                    OrderStatus = "Pending",
                    TotalPrice = 2.49m,
                    CreatedAt = DateTime.Now,
                    UserId = 2
                }
            };
        }
    }
}
