using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TastyTreats.Models
{
    public class ApplicationUser:IdentityUser<int>
    {
        public string? Address { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

      
        [MinLength(8, ErrorMessage = "Password must be greater than 8 characters")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Password should contain capital and small latter, numbers, and special characters")]
        [DataType(DataType.Password)]

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public string? UserPicture { get; set; }

        [StringLength(10)]
        public string? ZipCode { get; set; }

        [StringLength(50)]
        public string? Country { get; set; }

    
        [StringLength(50)]
        public string? City { get; set; }
   
        [RegularExpression(@"^\d{11}$", ErrorMessage = "The phone number must be exactly 11 digits.")]
        public int? Phone { get; set; }
        // Relationships
        public UserRole Role { get; set; }
        public Cart? Cart { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
