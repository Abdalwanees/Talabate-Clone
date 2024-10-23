using System.ComponentModel.DataAnnotations;

namespace Talabate.Clone.API.DTOs
{
    public class LogInDto
    {
        [Required(ErrorMessage ="Email Required")]
        [EmailAddress(ErrorMessage ="Invalid Email type")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
