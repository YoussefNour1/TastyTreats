using TastyTreats.Models;

namespace TastyTreats.Contexts.DummyData
{
    public class DummyOrderItemContext
    {
        public static List<OrderItem> GetOrderItems()
        {
            return new List<OrderItem>
            {
                new OrderItem
                {
                    OrderItemId = 1,
                    Quantity = 2,
                 
                    CreatedAt = DateTime.Now,
                    OrderId = 1,
                    ItemId = 1
                },
                new OrderItem
                {
                    OrderItemId = 2,
                    Quantity = 1,
                   
                    CreatedAt = DateTime.Now,
                    OrderId = 2,
                    ItemId = 2
                }
            };
        }
    }
}
