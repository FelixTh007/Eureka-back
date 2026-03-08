using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Eureka.Models;
using Microsoft.IdentityModel.Tokens;

namespace Eureka.Api.Services.Auth;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;

    public TokenService(IConfiguration config)
    {
        _config = config;
    }

    public string GenerateToken(Candidate candidate)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, candidate.Id.ToString()),
            new Claim(ClaimTypes.Email, candidate.Email),
            new Claim(ClaimTypes.Role, "CANDIDATE")
        };

        // Récupère la clé secrète depuis appsettings.json
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}