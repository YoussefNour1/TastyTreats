using System.ComponentModel.DataAnnotations;

namespace TastyTreats.Models
{
    public class CartItem
    {
        //Server Side Validation

        [Key]
        public int CartItemId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]  //Check that the cart item quantity is positive
        public int Quantity { get; set; }

        //[Required]
        //[Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")] //Check that price can not be zero
        //public decimal Price { get; set; }

        // Relationship remains the same

       
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        [Required]       //Check That a valid item is associated with the cart item
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }

}
