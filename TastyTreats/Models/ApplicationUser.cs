using Microsoft.AspNetCore.Identity;

namespace TastyTreats.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}
