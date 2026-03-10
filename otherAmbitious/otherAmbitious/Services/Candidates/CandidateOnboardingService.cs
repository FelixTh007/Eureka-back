// ===============================
// Eureka.Api/Services/Candidates/CandidateOnboardingService.cs
// ===============================
using Eureka.Api.DTOs.Candidates;
using Eureka.Api.Services.Security;
using Eureka.Api.Services.Storage;
using Eureka.Domain.Candidates;
using Eureka.Domain.Users;
using Eureka.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Eureka.Api.Services.Candidates;

public sealed class CandidateOnboardingService : ICandidateOnboardingService
{
    private readonly EurekaDbContext _db;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IBlobStorageService _blobStorage;

    public CandidateOnboardingService(EurekaDbContext db, IPasswordHasher passwordHasher, IBlobStorageService blobStorage)
    {
        _db = db;
        _passwordHasher = passwordHasher;
        _blobStorage = blobStorage;
    }

    public async Task<CandidateRegisterResponseDto> RegisterWithProfileAndCvAsync(
        CandidateRegisterRequestDto request,
        IFormFile cvFile,
        CancellationToken ct = default)
    {
        if (cvFile is null || cvFile.Length <= 0)
            throw new InvalidOperationException("Le CV est obligatoire.");

        // (V1) On accepte PDF et Word (tu peux élargir)
        var allowed = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "application/pdf",
            "application/msword",
            "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
        };

        if (!allowed.Contains(cvFile.ContentType))
            throw new InvalidOperationException("Format CV non supporté. Autorisés: PDF/DOC/DOCX.");

        var normalizedEmail = request.Email.Trim().ToLowerInvariant();

        // Email unique
        var exists = await _db.Users.AsNoTracking().AnyAsync(u => u.Email == normalizedEmail, ct);
        if (exists)
            throw new InvalidOperationException("Cet email est déjà utilisé.");


        var strategy = _db.Database.CreateExecutionStrategy();

        return await strategy.ExecuteAsync(async () =>
        {
            // Transaction: User + Profile + Upload + CandidateDocument
            await using var tx = await _db.Database.BeginTransactionAsync(ct);

            var now = DateTime.UtcNow;

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = normalizedEmail,
                PasswordHash = _passwordHasher.HashPassword(request.Password),
                IsActive = true,
                CreatedAt = now,
                UpdatedAt = now
            };

            _db.Users.Add(user);

            // Récupérer le rôle CANDIDATE
            var candidateRole = await _db.Roles
                .SingleAsync(r => r.Code == "CANDIDATE", ct);

            // Lier User ↔ Role
            _db.UserRoles.Add(new UserRole
            {
                UserId = user.Id,
                RoleId = candidateRole.Id,
                CreatedAt = now
            });

            // CandidateProfile PK = UserId (selon ton diagramme)
            var profile = new CandidateProfile
            {
                UserId = user.Id,
                FirstName = request.FirstName.Trim(),
                LastName = request.LastName.Trim(),
                Phone = request.Phone.Trim(),
                Commune = string.IsNullOrWhiteSpace(request.Commune) ? null : request.Commune.Trim(),
                Summary = string.IsNullOrWhiteSpace(request.Summary) ? null : request.Summary.Trim(),
                CreatedAt = now,
                UpdatedAt = now
            };

            _db.CandidateProfiles.Add(profile);

            // Upload Blob
            await using var stream = cvFile.OpenReadStream();
            var (blobName, absoluteUrl) = await _blobStorage.UploadCandidateCvAsync(
                candidateUserId: user.Id,
                content: stream,
                originalFileName: cvFile.FileName,
                contentType: cvFile.ContentType,
                ct: ct);

            // On stocke le chemin relatif (recommandé) dans StorageUrl
            // (tu peux stocker absoluteUrl si tu préfères, mais pas de SAS ici)
            var candidateDoc = new CandidateDocument
            {
                Id = Guid.NewGuid(),
                CandidateUserId = user.Id,
                Type = DocumentType.CV,
                Title = "CV",
                FileName = cvFile.FileName,
                MimeType = cvFile.ContentType,
                FileSize = (int)Math.Min(cvFile.Length, int.MaxValue),
                StorageUrl = blobName, // <- champ correspondant Azure Blob
                IsDefault = true,
                CreatedAt = now
            };

            _db.CandidateDocuments.Add(candidateDoc);

            await _db.SaveChangesAsync(ct);
            await tx.CommitAsync(ct);

            return new CandidateRegisterResponseDto
            {
                UserId = user.Id,
                CandidateUserId = user.Id,
                CvDocumentId = candidateDoc.Id
            };
        });
    }

 // new methode 

    public async Task<IEnumerable<CandidateRegisterResponseDto>> GetAllCandidatesAsync()
    {
        // 1. On récupère les profils des candidats depuis la base de données
        var profiles = await _db.CandidateProfiles
            .AsNoTracking()
            .ToListAsync();

        // 2. On transforme chaque profil en DTO pour l'API
        return profiles.Select(p => new CandidateRegisterResponseDto
        {
            UserId = p.UserId,
            CandidateUserId = p.UserId,
            // On peut laisser l'ID du document à Guid.Empty ou null 
            // si on ne veut pas charger les fichiers ici
            CvDocumentId = Guid.Empty 
        });
    }
}
