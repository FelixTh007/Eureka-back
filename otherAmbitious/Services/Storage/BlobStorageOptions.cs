// ===============================
// Eureka.Api/Services/Storage/BlobStorageOptions.cs
// ===============================
namespace Eureka.Api.Services.Storage;

public sealed class BlobStorageOptions
{
    public string ConnectionString { get; set; } = null!;
    public string ContainerName { get; set; } = "candidate-documents";
}
