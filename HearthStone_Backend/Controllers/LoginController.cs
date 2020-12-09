using HearthStone_Backend.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HearthStone_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public LoginController(
            UserManager<User> userManager,
            SignInManager<User> singInManager)
        {
            _userManager = userManager;
            _signInManager = singInManager;
        }


        [HttpPost]
        [EnableCors]
        public async Task<User> LoginUser([FromBody] User loggerUser)
        {

            var targetUser = await _userManager.FindByEmailAsync(loggerUser.Email);

            if (targetUser != null)
            {

                var signInResult = await _signInManager.CheckPasswordSignInAsync(targetUser, loggerUser.Password, false);

                if (signInResult.Succeeded)
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
