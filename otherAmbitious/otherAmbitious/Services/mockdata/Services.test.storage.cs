using Eureka.Api.Services.Storage; // Pour l'interface IBlobStorageService

namespace Eureka.Api.Services.Storage; // Même namespace que l'interface

public class MockBlobStorageService : IBlobStorageService
{
    public async Task<(string blobName, string absoluteUrl)> UploadCandidateCvAsync(
        Guid candidateUserId, 
        Stream content, 
        string originalFileName, 
        string contentType, 
        CancellationToken ct)
    {
        // On simule une réussite sans rien faire réellement
        return await Task.FromResult(("mock-file-name.pdf", "https://localhost/uploads/mock.pdf"));
    }
}