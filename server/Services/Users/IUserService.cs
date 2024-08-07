using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models.Users;

namespace server.Services.Users
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(UserRegisterDto userDto);
        Task<User?> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
