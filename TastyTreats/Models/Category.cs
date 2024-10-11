using System.ComponentModel.DataAnnotations;

namespace TastyTreats.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        // Relationships
        public ICollection<Item>? Items { get; set; }
    }

}