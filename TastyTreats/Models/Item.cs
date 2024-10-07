using System.ComponentModel.DataAnnotations;

namespace TastyTreats.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string? ItemPicture { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal? Discount { get; set; }

        public decimal FinalPrice
        {
            get
            {
                return Discount.HasValue ? Price - Discount.Value : Price;
            }
        }

        public string Description { get; set; }

        public bool Availability { get; set; }

        // Relationships
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
        public ICollection<CartItem>? CartItems { get; set; }
    }

}
