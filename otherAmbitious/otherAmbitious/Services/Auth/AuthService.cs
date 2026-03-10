using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Eureka.Api.DTOs.Auth;
using Eureka.Api.Services.Security;
using Eureka.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Eureka.Api.Services.Auth;

public sealed class AuthService : IAuthService
{
    private readonly EurekaDbContext _db;
    private readonly IPasswordHasher _passwordHasher;
    private readonly JwtOptions _jwt;

    public AuthService(EurekaDbContext db, IPasswordHasher passwordHasher, IOptions<JwtOptions> jwtOptions)
    {
        _db = db;
        _passwordHasher = passwordHasher;
        _jwt = jwtOptions.Value;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request, CancellationToken ct = default)
    {
        var email = request.Email.Trim().ToLowerInvariant();

        var user = await _db.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.Email == email && u.IsActive, ct);

        // message volontairement générique (sécurité)
        if (user is null)
            throw new InvalidOperationException("Identifiants invalides.");

        if (!_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
            throw new InvalidOperationException("Identifiants invalides.");

        // Charger les rôles (via UserRole -> Role)
        var roles = await _db.UserRoles
            .AsNoTracking()
            .Where(ur => ur.UserId == user.Id)
            .Join(_db.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => r.Code)
            .ToArrayAsync(ct);

        var now = DateTime.UtcNow;
        var expires = now.AddMinutes(_jwt.AccessTokenMinutes);

        var token = CreateJwt(user.Id, user.Email, roles, now, expires);

        return new LoginResponseDto
        {
            AccessToken = token,
            ExpiresAtUtc = expires,
            UserId = user.Id,
            Email = user.Email,
            Roles = roles
        };
    }

    private string CreateJwt(Guid userId, string email, string[] roles, DateTime issuedAtUtc, DateTime expiresAtUtc)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SigningKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new(JwtRegisteredClaimNames.Email, email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iat, new DateTimeOffset(issuedAtUtc).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
        };

        // Important: ClaimTypes.Role => [Authorize(Roles="...")] fonctionnera
        foreach (var role in roles)
            claims.Add(new Claim(ClaimTypes.Role, role));

        var jwt = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            notBefore: issuedAtUtc,
            expires: expiresAtUtc,
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}
