using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TastyTreats.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? Address { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }

        public string? Phone { get; set; }

        public string? UserPicture { get; set; }
        public int? CartId { get; set; }
        public int? OrderId { get; set; }

        public Cart? Cart { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
