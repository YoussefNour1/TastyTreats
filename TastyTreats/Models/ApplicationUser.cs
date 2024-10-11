using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TastyTreats.Models
{
    public class ApplicationUser:IdentityUser<int>
    {
        public string? Address { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        [RegularExpression(@"^\d{11}$", ErrorMessage = "The phone number must be exactly 11 digits.")]
        public int Phone { get; set; }
        public Cart? Cart { get; set; }
        public ICollection<Order>? Orders { get; set; }

    }
}
