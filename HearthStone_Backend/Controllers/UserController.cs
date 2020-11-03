using System.IO;
using System.Threading.Tasks;
using HearthStone_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

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

        [HttpPost]
        [Route("registration")]
        public async Task<User> CreateUser([FromBody] User user)
        {

            _userRepository.AddUser(user);

            return user;
        }
    }
}