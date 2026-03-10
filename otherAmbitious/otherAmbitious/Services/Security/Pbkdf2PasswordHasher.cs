// ===============================
// Eureka.Api/Services/Security/Pbkdf2PasswordHasher.cs
// ===============================
using System.Security.Cryptography;

namespace Eureka.Api.Services.Security;

public sealed class Pbkdf2PasswordHasher : IPasswordHasher
{
    // Valeurs recommandées "raisonnables" pour un Web API V1.
    // Tu peux ajuster selon perf/infra.
    private const int SaltSize = 16;         // 128-bit
    private const int KeySize = 32;          // 256-bit
    private const int Iterations = 100_000;  // PBKDF2 itérations
    private static readonly HashAlgorithmName Algo = HashAlgorithmName.SHA256;

    // Format stocké: PBKDF2$iterations$saltBase64$hashBase64
    public string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var key = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algo, KeySize);

        return $"PBKDF2${Iterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(key)}";
    }

    public bool VerifyPassword(string password, string storedHash)
    {
        if (string.IsNullOrWhiteSpace(storedHash)) return false;

        var parts = storedHash.Split('$');
        if (parts.Length != 4) return false;
        if (!parts[0].Equals("PBKDF2", StringComparison.OrdinalIgnoreCase)) return false;
        if (!int.TryParse(parts[1], out var iterations)) return false;

        byte[] salt, expected;
        try
        {
            salt = Convert.FromBase64String(parts[2]);
            expected = Convert.FromBase64String(parts[3]);
        }
        catch
        {
            return false;
        }

        var actual = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, Algo, expected.Length);
        return CryptographicOperations.FixedTimeEquals(actual, expected);
    }
}

