using EcommerceApp.Model;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcommerceApp.Services
{
    public class TokenService
    {
        public string CreateToken(User user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperHeroISCaptainDeadpoolandSuperMan!!!!!"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
           new Claim(ClaimTypes.Name, user.UserName),
           
            
                // Add other claims as needed
            };

            var tokeOptions = new JwtSecurityToken(
            issuer: "",
            claims: claims,
            expires: DateTime.Now.AddMinutes(2),
            signingCredentials: signinCredentials
         );


            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;






        }

    }
}
