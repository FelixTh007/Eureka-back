using Eureka.Api.DTOs.Auth;
using Eureka.Api.Services.Auth; 

namespace Eureka.Api.Endpoints;


public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/auth").WithTags("Auth");

        group.MapPost("/login", async (LoginRequestDto request, IAuthService authService) =>
        {
            
            var result = await authService.LoginAsync(request);

            if (result == null) return Results.Unauthorized();

            return Results.Ok(result);
        })
        .AllowAnonymous()
        .DisableAntiforgery();
    }
}



