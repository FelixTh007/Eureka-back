using System.ComponentModel.DataAnnotations;
      
namespace Eureka.Api.DTOs.Candidates;


public record CandidateRegisterRequestDto(
    [Required, EmailAddress, MaxLength(320)] string Email,
    [Required, MinLength(8)] string Password,
    [Required, MaxLength(100)] string FirstName,
    [Required, MaxLength(100)] string LastName,
    [Required, MaxLength(30)] string Phone,
    [MaxLength(100)] string? Commune,
    [MaxLength(1000)] string? Summary
);

public record CandidateRegisterResponseDto(
    Guid UserId,
    string FullName,
    string Status
);