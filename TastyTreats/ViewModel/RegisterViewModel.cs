using System.ComponentModel.DataAnnotations;

namespace TastyTreats.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="UserName must be required")]
        [MinLength(3,ErrorMessage ="UserName at least contains 3 Characters")]
        [MaxLength(50,ErrorMessage = "UserName must not exceeds 50 Characters ")]
        [Display(Name = "Username:")]
        public string  UserName { get; set; }

        [Required(ErrorMessage = "Email must be required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email:")]
        public string  Email { get; set; }

        [Required(ErrorMessage = "Address must be required")]
        [RegularExpression(@"^[a-zA-Z]+(?:\s?[a-zA-Z]+)?\s-\s[a-zA-Z]+\s-\s[a-zA-Z]+$",
         ErrorMessage = "Address must be in the format 'City - Region - Country' (e.g., NasrCity - Cairo - Egypt)")]
        [Display(Name = "Address:")]
        public string  Address { get; set; }

        [Required(ErrorMessage = "Password must be required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string  Password { get; set; }

        [Required]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string  ConfirmPassword { get; set; }
    }
}
