using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using HearthStone_Backend.Models;
using HearthStone_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;

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

            //_userRepository.AddUser(user);

            var result = await _userManager.CreateAsync(user, user.Password);

            if (result.Succeeded)
            {
                Console.WriteLine("Registralt!!!!");
            }

            return user;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<bool> LoginUser([FromBody] User loggerUser)
        {
            //User targetUser = _userRepository.GetUserByEmail(loggerUser.Email);


            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, loggerUser.UserName),
                new Claim(ClaimTypes.Name, loggerUser.UserName),
                new Claim(ClaimTypes.Role, "User"),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = true
            };


            var targetUser = await _userManager.FindByEmailAsync(loggerUser.Email);
            
            bool loginResult = false;

            if (targetUser != null)
            {

                //loginResult = _passwordHasher.VerifyPasswords(loggerUser.Password, targetUser.Password);
                loginResult = true;
                if(loginResult)
                {
                    
                        var signInResult = await _signInManager.CheckPasswordSignInAsync(targetUser, targetUser.Password, false);
                        Console.WriteLine(signInResult.Succeeded);

                        if(signInResult.Succeeded)
                        {

                            var result = await _signInManager.PasswordSignInAsync(targetUser, targetUser.Password,true,false);
                            Console.WriteLine(result.Succeeded);
                        }
                    
                    
                }

            }

            return loginResult;
        }
    }
}