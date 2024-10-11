using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TastyTreats.ViewModel
{
    [Keyless]
    public class AddRoleViewModel
    {

        [Required]
        [Display(Name = "Role Name")]
        public string Name { get; set; }
    }
}
