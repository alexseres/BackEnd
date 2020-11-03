using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using HearthStone_Backend.Models;
using HearthStone_Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(
            ICardRepository repository,
            PasswordHasher passwordHasher,
            UserManager<User> userManager,
            SignInManager<User> singInManager)
        {
            _userRepository = repository;
            _passwordHasher = passwordHasher;
            _userManager = userManager;
            _signInManager = singInManager;
        }

        [HttpPost]
        [Route("registration")]
        public async Task<User> CreateUser([FromBody] User user)
        {
            string hashedPW = _passwordHasher.CreateHashedPassword(user.Password);

            user.PasswordHash = hashedPW;

            _userRepository.AddUser(user);

            return user;
        }

        [HttpPost]
        [Route("login")]
        public async Task<bool> LoginUser([FromBody] User loggerUser)
        {
            User targetUser = _userRepository.GetUserByEmail(loggerUser.Email);

            bool loginResult = false;

            if (targetUser != null)
            {

                loginResult = _passwordHasher.VerifyPasswords(loggerUser.Password, targetUser.PasswordHash);
            
                if(loginResult)
                {
                    try
                    {
                        await _signInManager.SignInAsync(targetUser, false);
                        Console.WriteLine("Logged IN!!!!!!!!!!!!!!!!!!");

                    } catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

            }

            return loginResult;
        }
    }
}