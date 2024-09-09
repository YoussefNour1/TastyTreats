using System.ComponentModel.DataAnnotations;

namespace TastyTreats.Models
{
    public class Cart
    {
        //Server Side validation

        [Key]
        public int CartId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")] //Check that the cart quantity is positive
        public int Quantity { get; set; }

        // Corrected Relationship: A Cart belongs to one User

        [Required]     //check that the user is associated with the cart
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
