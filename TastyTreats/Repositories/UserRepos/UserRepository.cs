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

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User> AddUserAsync(User user)
        {
            user.UserPicture = user.UserPicture ?? "/img/default.png";
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            var previous = await _context.Users.AsNoTracking().FirstOrDefaultAsync(U => U.UserId == user.UserId);
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
