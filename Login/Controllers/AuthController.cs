using Login.Data;
using Login.DTOs;
using Login.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Login.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly UserDao _userDao;

        public AuthController(JwtService jwtService, UserDao userDao)
        {
            _jwtService = jwtService;
            _userDao = userDao;
        }

        [HttpPost("signup")]
        public IActionResult Signup([FromBody] UserDto userDto)
        {
            var existingUser = _userDao.GetUserByUsername(userDto.Username);
            if (existingUser != null)
            {
                return BadRequest(new { message = "Username already exists" });
            }

            var user = new User
            {
                Username = userDto.Username,
                Password = userDto.Password
            };

            _userDao.AddUser(user);     //save new user to the database
            return Ok(new { message = "User created successfully!" });  //success message if user is created successfully
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDto userDto)
        {
            var user = _userDao.GetUser(userDto.Username, userDto.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            var token = _jwtService.GenerateSecurityToken(user.Username);   //generate jwt token for the authenticated user
            return Ok(new { token });   //return the jwt token
        }
    }
}
