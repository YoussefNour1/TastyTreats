using System.ComponentModel.DataAnnotations;
namespace TastyTreats.Models
{
    public enum UserRole
    {
        Admin = 1,
        User = 2
    }

    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be greater than 8 characters")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Password should contain capital and small latter, numbers, and special characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? UserPicture { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        // Relationships
        public UserRole Role { get; set; }
        public Cart? Cart { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }

}
