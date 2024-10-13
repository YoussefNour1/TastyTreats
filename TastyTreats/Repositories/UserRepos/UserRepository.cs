using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TastyTreats.Contexts;
using TastyTreats.Models;

namespace TastyTreats.Repositories.UserRepos
{
    public class UserRepository : IUserRepository
    {
        private readonly TastyTreatsContext _context;

        public UserRepository(TastyTreatsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ApplicationUser> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<ApplicationUser> AddUserAsync(ApplicationUser user)
        {
            user.UserPicture = user.UserPicture ?? "/img/default.png";
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateUserAsync(ApplicationUser user)
        {
            var previous = await _context.Users.AsNoTracking().FirstOrDefaultAsync(U => U.Id == user.Id);
            user.UserPicture = user.UserPicture ?? previous!.UserPicture;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await GetUserByIdAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
