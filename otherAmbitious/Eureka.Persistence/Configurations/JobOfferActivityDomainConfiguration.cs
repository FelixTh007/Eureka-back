using Eureka.Domain.Offers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eureka.Persistence.Configurations;

public sealed class JobOfferActivityDomainConfiguration : IEntityTypeConfiguration<JobOfferActivityDomain>
{
    public void Configure(EntityTypeBuilder<JobOfferActivityDomain> b)
    {
        b.ToTable("job_offer_activity_domains");

        b.HasKey(x => new { x.JobOfferId, x.ActivityDomainId });

        b.Property(x => x.CreatedAt).IsRequired();

        b.HasOne(x => x.JobOffer)
            .WithMany(x => x.ActivityDomains)
            .HasForeignKey(x => x.JobOfferId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(x => x.ActivityDomain)
            .WithMany(x => x.JobOffers)
            .HasForeignKey(x => x.ActivityDomainId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
