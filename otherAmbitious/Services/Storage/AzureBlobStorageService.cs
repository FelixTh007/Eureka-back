// ===============================
// Eureka.Api/Services/Storage/AzureBlobStorageService.cs
// ===============================
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Eureka.Api.Services.Storage;

public sealed class AzureBlobStorageService : IBlobStorageService
{
    private readonly BlobContainerClient _container;

    public AzureBlobStorageService(BlobServiceClient blobServiceClient, BlobStorageOptions options)
    {
        _container = blobServiceClient.GetBlobContainerClient(options.ContainerName);
    }

    public async Task<(string BlobName, string AbsoluteUrl)> UploadCandidateCvAsync(
        Guid candidateUserId,
        Stream content,
        string originalFileName,
        string contentType,
        CancellationToken ct = default)
    {
        // Container privé
        await _container.CreateIfNotExistsAsync(PublicAccessType.None, cancellationToken: ct);

        var safeName = Path.GetFileName(originalFileName);
        var extension = Path.GetExtension(safeName);
        var blobName = $"cv/{candidateUserId:D}/{Guid.NewGuid():D}{extension}".ToLowerInvariant();

        var blobClient = _container.GetBlobClient(blobName);

        await blobClient.UploadAsync(
            content,
            new BlobUploadOptions
            {
                HttpHeaders = new BlobHttpHeaders { ContentType = contentType }
            },
            ct);

        return (blobName, blobClient.Uri.ToString());
    }
}
