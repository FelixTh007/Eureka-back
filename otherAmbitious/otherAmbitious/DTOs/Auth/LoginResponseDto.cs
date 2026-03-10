namespace Eureka.Api.DTOs.Auth;

public sealed class LoginResponseDto
{
    public string AccessToken { get; set; } = null!;
    public DateTime ExpiresAtUtc { get; set; }

    public Guid UserId { get; set; }
    public string Email { get; set; } = null!;
    public string[] Roles { get; set; } = Array.Empty<string>();
}
