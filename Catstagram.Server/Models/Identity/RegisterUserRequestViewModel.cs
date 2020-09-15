using System.ComponentModel.DataAnnotations;

namespace Catstagram.Server.Models.Identity
{
    public class RegisterUserRequestViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
