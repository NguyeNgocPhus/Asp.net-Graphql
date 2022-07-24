using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Configurations;
using Infrastructure.Services.Interfaces;
using Infrastructure.Services.Response;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services;

public class AuthorizationService : IAuthorizationService
{

    private readonly JwtConfiguration _jwtOption;

    public AuthorizationService(IOptions<JwtConfiguration> jwtOption)
    {
        _jwtOption= jwtOption.Value;
    }

    public JwtValidationResponse ValidateJwtAsync(string jwt, CancellationToken cancellationToken = default(CancellationToken))
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new TokenValidationParameters  
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = _jwtOption.Audience,
            ValidIssuer =  _jwtOption.Issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.SymmetricSecurityKey))
        };
        SecurityToken validatedToken;
        var claims =  tokenHandler.ValidateToken(jwt, tokenDescriptor , out validatedToken);
        return new JwtValidationResponse()
        {
            Claim = claims
        };
    }

    public GenerateJwtResponse GenerateJwtAsync(ClaimsIdentity claimsIdentity, CancellationToken cancellationToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtOption.SymmetricSecurityKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Audience = _jwtOption.Audience,
            Issuer = _jwtOption.Issuer,
            Subject = claimsIdentity,
            Expires = DateTime.UtcNow.AddHours(_jwtOption.Expires),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        return new GenerateJwtResponse()
        {
            accessToken = token,
            refeshToken = token
        };
    }
}