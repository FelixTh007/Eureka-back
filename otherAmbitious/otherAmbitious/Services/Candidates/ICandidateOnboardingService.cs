// ===============================
// Eureka.Api/Services/Candidates/ICandidateOnboardingService.cs
// ===============================
using Eureka.Api.DTOs.Candidates;
using Microsoft.AspNetCore.Http;

namespace Eureka.Api.Services.Candidates;

public interface ICandidateOnboardingService
{
    Task<CandidateRegisterResponseDto> RegisterWithProfileAndCvAsync(
        CandidateRegisterRequestDto request,
        IFormFile cvFile,
        CancellationToken ct = default);
        
    Task<IEnumerable<CandidateRegisterResponseDto>> GetAllCandidatesAsync();
}
