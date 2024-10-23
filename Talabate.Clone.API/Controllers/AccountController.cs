using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Talabate.Clone.API.DTOs;
using Talabate.Clone.API.Errors;
using Talabate.Clone.Core.Entites.Identity;
namespace Talabate.Clone.API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager; // Corrected typo

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager; // Corrected typo
        }

        [HttpPost("LogIn")]
        public async Task<ActionResult<UserDto>> LogIn(LogInDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return Unauthorized(new ApiResponse(401, "Unauthorized User"));

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded) return Unauthorized(new ApiResponse(401, "Unauthorized User"));

            // Implement actual token generation logic here
            var token = "This will be a JWT token"; // Placeholder for token generation

            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = token
            });
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<UserDto>> SignUp(RegisterDto model)
        {
            var user = new AppUser()
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.Email.Split('@')[0],
                PhoneNumber = model.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, model.Password); // Corrected typo

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList(); // Collect error messages
                return BadRequest(new ApiResponse(400, string.Join(", ", errors))); // Return specific error messages
            }

            var token = "This will be a JWT token"; 

            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = token
            });
        }
    }
}
