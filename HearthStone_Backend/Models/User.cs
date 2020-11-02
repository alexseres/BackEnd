using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace HearthStone_Backend.Models
{
    public class User
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        
    }
}