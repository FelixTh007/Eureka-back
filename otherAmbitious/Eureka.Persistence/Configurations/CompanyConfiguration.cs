using Eureka.Domain.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eureka.Persistence.Configurations;

public sealed class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> b)
    {
        b.ToTable("companies");

        b.HasKey(x => x.Id);

        b.Property(x => x.Name).HasMaxLength(255).IsRequired();
        b.Property(x => x.Siret).HasMaxLength(14); // optionnel V1

        b.Property(x => x.Sector).HasMaxLength(150);
        b.Property(x => x.Phone).HasMaxLength(30);
        b.Property(x => x.Email).HasMaxLength(255);
        b.Property(x => x.Address).HasMaxLength(255);

        b.Property(x => x.CreatedAt).IsRequired();
        b.Property(x => x.UpdatedAt).IsRequired();

        // Azure SQL : index unique filtré sur SIRET (uniquement si renseigné)
        b.HasIndex(x => x.Siret)
            .IsUnique()
            .HasFilter("[Siret] IS NOT NULL");
    }
}
