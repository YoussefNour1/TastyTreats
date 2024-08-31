using System.ComponentModel.DataAnnotations;

namespace TastyTreats.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        public int Quantity { get; set; }

        // Corrected Relationship: A Cart belongs to one User
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
