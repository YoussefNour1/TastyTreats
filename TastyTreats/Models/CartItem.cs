using System.ComponentModel.DataAnnotations;

namespace TastyTreats.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        // Relationship remains the same
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    
    }

}
