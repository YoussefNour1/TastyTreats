using System.ComponentModel.DataAnnotations;

namespace TastyTreats.Models
{
    public class Cart
    {
        //Server Side validation

        [Key]
        public int CartId { get; set; }

      

        // Corrected Relationship: A Cart belongs to one User

        [Required]     //check that the user is associated with the cart
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
