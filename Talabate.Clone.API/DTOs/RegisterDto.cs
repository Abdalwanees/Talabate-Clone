using System.ComponentModel.DataAnnotations;

namespace Talabate.Clone.API.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Display Name is required")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Email is Required"), EmailAddress(ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }  // Changed to string for flexibility

        [Required]
        //[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$", ErrorMessage = "Password must be at least 6 characters long and contain at least one letter and one number.")]
        public string Password { get; set; }
    }
}
