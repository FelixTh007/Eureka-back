using Microsoft.AspNetCore.Mvc;
using Eureka.Api.DTOs.Candidates;
using Eureka.Api.Services.Candidates;

namespace Eureka.Api.Endpoints;

public static class CandidateEndpoints
{
    public static void MapCandidateEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/candidates").WithTags("Candidates");

        
        group.MapGet("/", async (ICandidateOnboardingService onboarding) =>
        {
            var candidates = await onboarding.GetAllCandidatesAsync();
            return Results.Ok(candidates);
        })
        .AllowAnonymous();

        group.MapPost("/register", async (
            [FromForm] CandidateRegisterRequestDto request,
            [FromForm] IFormFile cvFile,
            ICandidateOnboardingService onboarding,
            CancellationToken ct) =>
        {
            if (cvFile is not { Length: > 0 }) 
                return Results.BadRequest("Le CV est obligatoire.");

            var result = await onboarding.RegisterWithProfileAndCvAsync(request, cvFile, ct);

            return Results.Created($"/api/candidates/{result.UserId}", result);
        })
        .Accepts<CandidateRegisterRequestDto>("multipart/form-data")
        .AllowAnonymous()
        .DisableAntiforgery();
    }
}