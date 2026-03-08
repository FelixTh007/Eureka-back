using System.ComponentModel.DataAnnotations;

namespace Eureka.Api.DTOs.Auth;

public sealed class LoginRequestDto
{
    [Required, EmailAddress, MaxLength(320)]
    public string Email { get; set; } = null!;

    [Required, MinLength(8), MaxLength(200)]
    public string Password { get; set; } = null!;
}
