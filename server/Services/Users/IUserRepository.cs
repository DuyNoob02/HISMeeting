using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models.Users;

namespace server.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
