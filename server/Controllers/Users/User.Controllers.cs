// create users controller

using Microsoft.AspNetCore.Mvc;
using server.Models.Users;
using server.Services.Users;
using Microsoft.AspNetCore.Authorization;
using server.Services.Auth;
namespace server.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        public UserController(IUserService userService, IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }
        // create register method
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _userService.RegisterUserAsync(userDto);
            return Ok(new { Message = "User registered successfully!", UserID = result.Id });
        }

        // create login method
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var token = await _authenticationService.AuthenticateUserAsync(loginDto);
            if (token == null)
            {
                return Unauthorized(new {Message = "Invalid credentials"});
            }
            return Ok(new { Token = token });
        }
        [HttpGet("GetUser")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}

