using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Helpers;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly _2404g1Context _context;
        private readonly TokenService _tokenService;

        public AuthController(_2404g1Context context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }


        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            // Check if user already exists
            var existingUser = _context.Users.FirstOrDefault(u => u.Username == user.Username);
            if (existingUser != null)
            {
                return BadRequest("User already exists.");
            }
            // Add new user to the database

            var hashedPassword = PasswordHasher.HashCode(user.PasswordHash);

            user.PasswordHash = hashedPassword;



            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]

        public IActionResult Login(User user)
        {
            var isUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);

            if (isUser == null)
            {
                return Unauthorized("User not found");
            }

            if(user.PasswordHash != PasswordHasher.HashCode(isUser.PasswordHash))
            {
                return Unauthorized("Invalid password");
            }

            var token = _tokenService.GenerateToken(isUser);

            return Ok(new { Token = token });

        }



    }
}
