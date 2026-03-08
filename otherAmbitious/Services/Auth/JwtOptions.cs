namespace Eureka.Api.Services.Auth;

public sealed class JwtOptions
{
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public string SigningKey { get; set; } = null!; // clé secrète (>= 32 chars recommandé)
    public int AccessTokenMinutes { get; set; } = 60;
}
