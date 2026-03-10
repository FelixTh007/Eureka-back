using Eureka.Domain.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eureka.Persistence.Configurations;

public sealed class CompanyNeedConfiguration : IEntityTypeConfiguration<CompanyNeed>
{
    public void Configure(EntityTypeBuilder<CompanyNeed> b)
    {
        b.ToTable("company_needs");

        b.HasKey(x => x.Id);

        b.Property(x => x.Title).HasMaxLength(255).IsRequired();
        b.Property(x => x.Description).IsRequired();
        b.Property(x => x.Location).HasMaxLength(150);
        b.Property(x => x.Urgency).HasMaxLength(50);

        b.Property(x => x.Status)
            .HasConversion<string>()
            .HasMaxLength(30)
            .IsRequired();

        b.Property(x => x.CreatedAt).IsRequired();
        b.Property(x => x.UpdatedAt).IsRequired();

        b.HasOne(x => x.Company)
            .WithMany(x => x.Needs)
            .HasForeignKey(x => x.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(x => x.CreatedByCompanyUser)
            .WithMany(x => x.CreatedNeeds)
            .HasForeignKey(x => x.CreatedByCompanyUserId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasIndex(x => new { x.CompanyId, x.Status, x.CreatedAt });
        b.HasIndex(x => x.CreatedByCompanyUserId);
    }
}
