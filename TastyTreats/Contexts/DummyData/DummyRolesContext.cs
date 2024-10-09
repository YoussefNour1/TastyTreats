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
                    Id = Guid.NewGuid().ToString(),
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },
                new Role
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "user",
                    NormalizedName = "USER"
                }
            };
        }
    }
}
