using Eureka.Domain.Users;
using Eureka.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Eureka.Api.Infrastructure.Persistence;

public static class RoleSeeder
{
    public static async Task SeedAsync(EurekaDbContext db, CancellationToken ct = default)
    {
        if (await db.Roles.AnyAsync(ct))
            return;

        var now = DateTime.UtcNow;

        var roles = new[]
        {
            new Role
            {
                Id = Guid.NewGuid(),
                Code = "CANDIDATE",
                Label = "Candidat"
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Code = "COUNSELOR",
                Label = "Conseiller"
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Code = "COMPANY",
                Label = "Entreprise"
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Code = "ADMIN",
                Label = "Administrateur"
            }
        };

        await db.Roles.AddRangeAsync(roles, ct);
        await db.SaveChangesAsync(ct);
    }
}
