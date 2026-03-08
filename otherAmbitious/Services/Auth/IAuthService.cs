using Eureka.Api.DTOs.Auth;

namespace Eureka.Api.Services.Auth;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto request, CancellationToken ct = default);
}
