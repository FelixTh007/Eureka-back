using Microsoft.EntityFrameworkCore;
using Eureka.Data;
using Eureka.Api.DTOs.Auth;
using Microsoft.AspNetCore.Identity;
using Eureka.Api.Services.Auth;
using Eureka.Models; // Assure-toi que c'est ici que se trouve 'Candidate'

public class AuthService : IAuthService
{
    private readonly AppDbContext _db;
    private readonly IPasswordHasher<Candidate> _passwordHasher; // Remplacé User par Candidate
    private readonly ITokenService _tokenService;

    public AuthService(AppDbContext db, IPasswordHasher<Candidate> passwordHasher, ITokenService tokenService)
    {
        _db = db;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto request)
    {
        
        var candidate = await _db.Candidates.FirstOrDefaultAsync(c => c.Email == request.Email);
        if (candidate == null) return null;

        var result = _passwordHasher.VerifyHashedPassword(candidate, candidate.PasswordHash, request.Password);
        if (result == PasswordVerificationResult.Failed) return null;

        var token = _tokenService.GenerateToken(candidate);

        return new LoginResponseDto
        {
            AccessToken = token,
            ExpiresAtUtc = DateTime.UtcNow.AddHours(1),
            UserId = candidate.Id,
            Email = candidate.Email,
            Roles = new[] { "CANDIDATE" } 
        };
    }
}