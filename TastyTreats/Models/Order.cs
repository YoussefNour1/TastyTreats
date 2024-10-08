using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TastyTreats.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public string OrderStatus { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Foreign Key
        [ForeignKey("User")]
        public int UserId { get; set; }

        // Navigation Property
        public ApplicationUser User { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
