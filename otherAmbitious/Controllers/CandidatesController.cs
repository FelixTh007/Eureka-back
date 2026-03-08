// ===============================
// Eureka.Api/Controllers/CandidatesController.cs
// ===============================
using Eureka.Api.DTOs.Candidates;
using Eureka.Api.Services.Candidates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eureka.Api.Controllers;

[ApiController]
[Route("api/candidates")]
// [Authorize(Roles ="CANDIDATE")]
public sealed class CandidatesController : ControllerBase
{
    private readonly ICandidateOnboardingService _onboarding;

    public CandidatesController(ICandidateOnboardingService onboarding)
    {
        _onboarding = onboarding;
    }

    // POST /api/candidates/register (multipart/form-data)
    [HttpPost("register")]
    [Consumes("multipart/form-data")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(CandidateRegisterResponseDto), StatusCodes.Status201Created)]
    public async Task<ActionResult<CandidateRegisterResponseDto>> Register(
        [FromForm] CandidateRegisterRequestDto request,
        [FromForm] IFormFile cvFile,
        CancellationToken ct)
    {
        var result = await _onboarding.RegisterWithProfileAndCvAsync(request, cvFile, ct);

        // Tu pourras plus tard fournir un GET /api/candidates/{id}
        return Created($"/api/candidates/{result.UserId}", result);
    }

    
    [HttpGet]
    [AllowAnonymous] // Permet l'accès sans token pour vos tests
    public async Task<ActionResult> GetAll()
    {
        // Au lieu de _context, demandez au service que vous avez déjà
        var candidates = await _onboarding.GetAllCandidatesAsync(); 
        return Ok(candidates);
    }
}

