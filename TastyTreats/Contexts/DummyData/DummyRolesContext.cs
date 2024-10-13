using Microsoft.AspNetCore.Mvc;
using TastyTreats.Models;
using TastyTreats.ViewModel;

namespace TastyTreats.Contexts.DummyData
{
    public class DummyRolesContext : Controller
    {
        public static List<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role
                {
                    Id = 1,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },
                new Role
                {
                    Id = 2,
                    Name = "user",
                    NormalizedName = "USER"
                }
            };
        }
    }
}
