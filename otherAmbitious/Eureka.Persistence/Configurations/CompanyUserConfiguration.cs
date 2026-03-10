using Eureka.Domain.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eureka.Persistence.Configurations;

public sealed class CompanyUserConfiguration : IEntityTypeConfiguration<CompanyUser>
{
    public void Configure(EntityTypeBuilder<CompanyUser> b)
    {
        b.ToTable("company_users");

        b.HasKey(x => x.Id);

        b.Property(x => x.CompanyRole)
            .HasConversion<string>()
            .HasMaxLength(30)
            .IsRequired();

        b.Property(x => x.CreatedAt).IsRequired();

        b.HasOne(x => x.Company)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(x => x.User)
            .WithMany(x => x.CompanyUsers)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasIndex(x => new { x.CompanyId, x.UserId }).IsUnique();
        b.HasIndex(x => x.UserId);
        b.HasIndex(x => x.CompanyId);
    }
}
