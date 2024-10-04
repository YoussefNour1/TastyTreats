using System.ComponentModel.DataAnnotations;

namespace TastyTreats.ViewModel
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
