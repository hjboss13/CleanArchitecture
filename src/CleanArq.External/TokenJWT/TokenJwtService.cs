using CleanArq.Application.External.TokenJwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArq.External.TokenJWT
{
    public class TokenJwtService : ITokenJwtService
    {
        private string secretKeyJwt;
        private string issuerJwt;
        string audienceJwt;

        private readonly IConfiguration config;

        public TokenJwtService(IConfiguration config)
        {
            this.config = config;

            secretKeyJwt = config["SecretKeyJwt"] ?? string.Empty;
            issuerJwt = config["IssuerJwt"] ?? string.Empty;
            audienceJwt = config["AudienceJwt"] ?? string.Empty;
        }

        public string Execute(string idUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var sigingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKeyJwt));

            var tokenDescriptor = new SecurityTokenDescriptor { 
                Subject = new ClaimsIdentity(new Claim[] { 
                    new Claim(ClaimTypes.Name, idUser),
                    new Claim("clave1", "valor1"),
                    new Claim("clave2", "valor2"),
                    new Claim("clave3", "valor3"),
                    new Claim("clave4", "valor4")
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(sigingKey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = issuerJwt,
                Audience = audienceJwt
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
