using System.ComponentModel.DataAnnotations;

namespace TastyTreats.Models
{
    public class Cart
    {
        //Server Side validation

        [Key]
        public int CartId { get; set; }

        // Corrected Relationship: A Cart belongs to one User
        [Required]    
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
