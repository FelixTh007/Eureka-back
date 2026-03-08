using Eureka.Api.DTOs.Candidates;
using Eureka.Api.Services.Candidates;

namespace Eureka.Api.Services.Candidates;

public class CandidateOnboardingService : ICandidateOnboardingService
{
    public  async Task<CandidateRegisterResponseDto> RegisterWithProfileAndCvAsync(
        CandidateRegisterRequestDto request, IFormFile cvFile, CancellationToken ct)
    {
        
        return new CandidateRegisterResponseDto(
            Guid.NewGuid(), 
            $"{request.FirstName} {request.LastName}", 
            "En attente"                           
        );
    }

    public async Task<IEnumerable<CandidateRegisterResponseDto>> GetAllCandidatesAsync()
    {
        return await Task.FromResult(new List<CandidateRegisterResponseDto>());
    }
}