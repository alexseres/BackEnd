using System.Threading.Tasks;
using HearthStone_Backend.Models;
using HearthStone_Backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HearthStone_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly PasswordHasher _passwordHasher;
        private readonly UserManager<User> _userManager;

        public RegisterController(
            PasswordHasher passwordHasher,
            UserManager<User> userManager)
        {
            _passwordHasher = passwordHasher;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<User> CreateUser([FromBody] User user)
        {
            string hashedPW = _passwordHasher.CreateHashedPassword(user.Password);

            user.PasswordHash = hashedPW;

            var result = await _userManager.CreateAsync(user, user.Password);

            return user;
        }
    }
}
