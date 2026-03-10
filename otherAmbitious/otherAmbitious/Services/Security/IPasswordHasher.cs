// ===============================
// Eureka.Api/Services/Security/IPasswordHasher.cs
// ===============================
namespace Eureka.Api.Services.Security;

public interface IPasswordHasher
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string storedHash);
}

