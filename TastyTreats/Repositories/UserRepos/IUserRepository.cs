using Microsoft.AspNetCore.Identity;
using TastyTreats.Models;

namespace TastyTreats.Repositories.UserRepos
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task<ApplicationUser> GetUserByIdAsync(int userId);
        Task<ApplicationUser> AddUserAsync(ApplicationUser user);
        Task UpdateUserAsync(ApplicationUser user);
        Task DeleteUserAsync(int userId);
    }
}
