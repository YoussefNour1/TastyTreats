using Microsoft.AspNetCore.Identity;

namespace TastyTreats.Models
{
    public class ApplicationUser:IdentityUser<int>
    {
        public string? Address { get; set; }
    }
}
