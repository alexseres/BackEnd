using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;

namespace HearthStone_Backend.Models
{
    public class User : IdentityUser
    {
        [Required]
        [Key]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Username { get; set; }
        
        public User(){}
        
    }
}