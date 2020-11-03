using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using HearthStone_Backend.Models;
using HearthStone_Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace HearthStone_Backend.Controllers
{
    [Route("userAPI")] 
    [ApiController]
    public class UserController
    {
        private readonly ICardRepository _userRepository;
        private readonly PasswordHasher _passwordHasher;

        public UserController(ICardRepository repository, PasswordHasher passwordHasher)
        {
            _userRepository = repository;
            _passwordHasher = passwordHasher;
        }

        [HttpPost]
        [Route("registration")]
        public async Task<User> CreateUser([FromBody] User user)
        {
            string hashedPW = _passwordHasher.CreateHashedPassword(user.Password);

            user.Password = hashedPW;

            _userRepository.AddUser(user);

            return user;
        }

        [HttpPost]
        [Route("login")]
        public async Task<bool> LoginUser([FromBody] User loggerUser)
        {
            User targetUser = _userRepository.GetUserByEmail(loggerUser.Email);

            bool loginResult = _passwordHasher.VerifyPasswords(loggerUser.Password, targetUser.Password);

            return loginResult;
        }
    }
}