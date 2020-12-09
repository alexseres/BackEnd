using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;

namespace HearthStone_Backend.Models
{
    public class User : IdentityUser
    {
        [Required]
        [Key]
        public override string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public override string UserName { get; set; }
    }
}