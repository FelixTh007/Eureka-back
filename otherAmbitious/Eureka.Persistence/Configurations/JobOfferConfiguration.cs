using Eureka.Domain.Offers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eureka.Persistence.Configurations;

public sealed class JobOfferConfiguration : IEntityTypeConfiguration<JobOffer>
{
    public void Configure(EntityTypeBuilder<JobOffer> b)
    {
        b.ToTable("job_offers");

        b.HasKey(x => x.Id);

        b.Property(x => x.Title).HasMaxLength(255).IsRequired();
        b.Property(x => x.Description).IsRequired();

        b.Property(x => x.ContractType).HasMaxLength(50);
        b.Property(x => x.Location).HasMaxLength(150);
        b.Property(x => x.SalaryRange).HasMaxLength(100);

        b.Property(x => x.Status)
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired();

        b.Property(x => x.CreatedAt).IsRequired();
        b.Property(x => x.UpdatedAt).IsRequired();

        // 1 besoin -> 0..1 offre : unique sur CompanyNeedId
        b.HasIndex(x => x.CompanyNeedId).IsUnique();

        b.HasOne(x => x.CompanyNeed)
            .WithOne(x => x.JobOffer)
            .HasForeignKey<JobOffer>(x => x.CompanyNeedId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(x => x.Company)
            .WithMany(x => x.JobOffers)
            .HasForeignKey(x => x.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(x => x.CreatedByCounselorUser)
            .WithMany(x => x.JobOffersCreated)
            .HasForeignKey(x => x.CreatedByCounselorUserId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasIndex(x => new { x.Status, x.PublishedAt });
        b.HasIndex(x => new { x.CompanyId, x.Status, x.PublishedAt });
    }
}
