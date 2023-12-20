using Domain.Models.UserModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authentication
{
    public class JWTtokenGenerator
    {
        private readonly IConfiguration _configuration;

        //In order go gain access to Appsetings and inject configuration we have to create constructor
        public JWTtokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //Public method that create JW token
        public string CreateJWTtoken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
             new(ClaimTypes.Name, user.Username),
             new(ClaimTypes.Role, user.Role!)
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
