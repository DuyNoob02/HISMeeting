using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Models.Users;
using server.Models.Context;

namespace server.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly HisMeetingContext _context;

        public UserRepository(HisMeetingContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User user)
        {
            System.Console.WriteLine(user);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
