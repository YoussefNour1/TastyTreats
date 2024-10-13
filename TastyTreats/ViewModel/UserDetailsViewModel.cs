using TastyTreats.Models;

namespace TastyTreats.ViewModel
{
    public class UserDetailsViewModel
    {
        public ApplicationUser User { get; set; }
        public List<string> Roles { get; set; }
    }
}
