// ===============================
// Eureka.Api/Services/Storage/IBlobStorageService.cs
// ===============================
namespace Eureka.Api.Services.Storage;

public interface IBlobStorageService
{
    /// <summary>
    /// Upload un fichier dans un container privé et retourne:
    /// - BlobName (chemin relatif dans le container)
    /// - AbsoluteUrl (URL sans SAS) utile pour debug/affichage interne
    /// </summary>
    Task<(string BlobName, string AbsoluteUrl)> UploadCandidateCvAsync(
        Guid candidateUserId,
        Stream content,
        string originalFileName,
        string contentType,
        CancellationToken ct = default);
}
