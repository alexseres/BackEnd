using System.Threading.Tasks;
using HearthStone_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace HearthStone_Backend.Controllers
{
    [Route("userAPI")] 
    [ApiController]
    public class UserController
    {
        private readonly ICardRepository _userRepository;

        public UserController(ICardRepository repository)
        {
            _userRepository = repository;
        }

        [Route("registration")]
        [HttpPost]
        public async Task<User> CreateUser(string email, string password)
        {
            var user = new User()
            {
                Email = email,
                Password = password
            };
            _userRepository.AddUser(user);
            return user;
        }
    }
}