using Application.Dtos;
using Domain.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Nest;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers.AuthUserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;

        //In order go gain access to Appsetings and inject configuration we have to create constructor
        public AuthUserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        public ActionResult<User> Register(UserDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.UserName = request.Username;
            user.UserPassword = passwordHash;

            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<User> Login(UserDto request)
        {
            if (user.UserName != request.Username)
            {
                return BadRequest("User not found");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.UserPassword))
            {
                return BadRequest("Wrong password");
            }

            string token = CreateToken(user);

            return Ok(token);
        }

        //Private method that create JW token
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
             new(ClaimTypes.Name, user.UserName),
             new(ClaimTypes.Role, "admin")
            };
            //this key is used to create and verify JWToken and to make sure that this token came from this application
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSetings:Token").Value!));

            //Signing credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            //generate token
            var token = new JwtSecurityToken(
                  claims: claims,
                  expires: DateTime.Now.AddDays(1),
                  signingCredentials: creds
                );

            //write the token
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
