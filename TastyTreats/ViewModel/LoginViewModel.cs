using System.ComponentModel.DataAnnotations;

namespace TastyTreats.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="UserName must be required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email must be required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password must be required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
