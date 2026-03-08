using Eureka.Api.DTOs.Candidates;


namespace Eureka.Api.Services.Candidates;

public interface ICandidateOnboardingService
{
    Task<CandidateRegisterResponseDto> RegisterWithProfileAndCvAsync(
        CandidateRegisterRequestDto request, 
        IFormFile cvFile, 
        CancellationToken ct);

    
    Task<IEnumerable<CandidateRegisterResponseDto>> GetAllCandidatesAsync();
}