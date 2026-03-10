// ===============================
// Eureka.Api/DTOs/Candidates/CandidateRegisterResponseDto.cs
// ===============================
namespace Eureka.Api.DTOs.Candidates;

public sealed class CandidateRegisterResponseDto
{
    public Guid UserId { get; set; }
    public Guid CandidateUserId { get; set; }  // = UserId (PK du CandidateProfile)
    public Guid CvDocumentId { get; set; }
}


