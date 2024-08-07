using System.Threading.Tasks;
using server.Models.Users;

namespace server.Services.Auth
{
    public interface IAuthenticationService
    {
        Task<User?> AuthenticateAsync(string email, string password);
        Task<string?> AuthenticateUserAsync(UserLoginDto loginDto);
        Task<string> GenerateJwtToken(User user);
    }
}