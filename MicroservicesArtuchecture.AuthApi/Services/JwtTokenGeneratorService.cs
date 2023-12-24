using MicroservicesArtuchecture.AuthApi.Contracts;
using MicroservicesArtuchecture.AuthApi.Storage.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MicroservicesArtuchecture.AuthApi.Services
{
    public class JwtTokenGeneratorService : IJwtTokenGeneratorService
    {
        private readonly JwtOptionsContract _jwtOptions;
        public JwtTokenGeneratorService(IOptions<JwtOptionsContract> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }
        public string GenerateToken(UserEntity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
            var cliams = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id),
            };

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Audience = _jwtOptions.Audience,
                Issuer = _jwtOptions.Issure,
                Subject = new ClaimsIdentity(cliams),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
