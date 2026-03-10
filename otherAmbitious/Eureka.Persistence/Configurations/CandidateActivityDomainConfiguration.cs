using Eureka.Domain.Candidates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eureka.Persistence.Configurations;

public sealed class CandidateActivityDomainConfiguration : IEntityTypeConfiguration<CandidateActivityDomain>
{
    public void Configure(EntityTypeBuilder<CandidateActivityDomain> builder)
    {
        builder.ToTable("CandidateActivityDomains");

        builder.HasKey(x => new { x.CandidateUserId, x.ActivityDomainId });

        builder.HasOne(x => x.CandidateProfile)
               .WithMany(cp => cp.ActivityDomains)
               .HasForeignKey(x => x.CandidateUserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.ActivityDomain)
               .WithMany(ad => ad.Candidates)
               .HasForeignKey(x => x.ActivityDomainId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
