
// ===============================
// Eureka.Api/DTOs/Candidates/CandidateRegisterRequestDto.cs
// ===============================
using System.ComponentModel.DataAnnotations;

namespace Eureka.Api.DTOs.Candidates;

public sealed class CandidateRegisterRequestDto
{
    [Required, EmailAddress, MaxLength(320)]
    [Display(Name ="Email")]
    public string Email { get; set; } = null!;

    [Required, MinLength(8), MaxLength(200)]
    [Display(Name ="Mot de passe")]
    public string Password { get; set; } = null!;

    [Required, MaxLength(100)]
    [Display(Name ="Prénom")]
    public string FirstName { get; set; } = null!;

    [Required, MaxLength(100)]
    [Display(Name ="Nom")]
    public string LastName { get; set; } = null!;

    [Required, MaxLength(30)]
    [Display(Name ="Téléphone")]
    public string Phone { get; set; } = null!;

    [MaxLength(100)]
    [Display(Name ="Commune")]
    public string? Commune { get; set; }

    [MaxLength(1000)]
    [Display(Name ="Présentation")]
    public string? Summary { get; set; }
}

