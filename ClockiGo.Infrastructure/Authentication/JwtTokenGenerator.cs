using ClockiGo.Application.Common.Interfaces.Authentication;
using ClockiGo.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClockiGo.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _settings;

        public JwtTokenGenerator(IOptions<JwtSettings> options)
        {
            _settings = options.Value;
        }

        public string GenerateToken(User user)
        {

            var signinClredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Secret)), SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName ),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName )
            };

            var securityToken = new JwtSecurityToken(issuer: _settings.Issuer,audience: _settings.Audience, expires: DateTime.UtcNow.AddDays(_settings.ExpiryDays), claims: claims, signingCredentials: signinClredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);

        }
    }
}
