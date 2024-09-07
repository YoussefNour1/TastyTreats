using System.ComponentModel.DataAnnotations;

namespace TastyTreats.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId  { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        // Relationships
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }

}
