using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using HearthStone_Backend.Models;
using HearthStone_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.HttpOverrides;

namespace HearthStone_Backend.Controllers
{
    [Route("userAPI")] 
    [ApiController]
    [EnableCors]
    public class UserController : ControllerBase
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
        [EnableCors]
        public async Task<User> LoginUser([FromBody] User loggerUser)
        {
            //User targetUser = _userRepository.GetUserByEmail(loggerUser.Email);        


            var targetUser = await _userManager.FindByEmailAsync(loggerUser.Email);
            
            bool loginResult = false;

            if (targetUser != null)
            {

                //loginResult = _passwordHasher.VerifyPasswords(loggerUser.Password, targetUser.Password);
                loginResult = true;
                if(loginResult)
                {
                    
                    var signInResult = await _signInManager.CheckPasswordSignInAsync(targetUser, targetUser.Password, false);

                    if(signInResult.Succeeded)
                    {

                        //var result = await _signInManager.PasswordSignInAsync(targetUser, targetUser.Password, false, false);
                        

                        var claims = new List<Claim> { 
                            new Claim(ClaimTypes.Email, targetUser.Email),
                            new Claim(ClaimTypes.Name, targetUser.UserName)
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                        //Console.WriteLine(result.Succeeded);

                        
                    }            
                }

            }

            return targetUser;
        }

        [HttpGet]
        [Route("auth")]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task AuthPage()
        {

        }
    }
}