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
        private readonly PasswordHasher _passwordHasher;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(
            PasswordHasher passwordHasher,
            UserManager<User> userManager,
            SignInManager<User> singInManager)
        {
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

            var result = await _userManager.CreateAsync(user, user.Password);

            return user;
        }

        [HttpPost]
        [Route("login")]
        [EnableCors]
        public async Task<User> LoginUser([FromBody] User loggerUser)
        {
            
            var targetUser = await _userManager.FindByEmailAsync(loggerUser.Email);
            
            if (targetUser != null)
            {
           
                var signInResult = await _signInManager.CheckPasswordSignInAsync(targetUser, targetUser.Password, false);

                if(signInResult.Succeeded)
                {                        

                    var claims = new List<Claim> { 
                        new Claim(ClaimTypes.Email, targetUser.Email),
                        new Claim(ClaimTypes.Name, targetUser.UserName)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));
                        
                }            
                
            }

            return targetUser;
        }
    }
}