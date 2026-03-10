using Eureka.Domain.Applications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eureka.Persistence.Configurations;

public sealed class ApplicationConfiguration : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.ToTable("Applications");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.CandidateProfile)
               .WithMany(cp => cp.Applications)
               .HasForeignKey(x => x.CandidateUserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.JobOffer)
               .WithMany(x => x.Applications) // ou JobOffer.Applications si tu l’as
               .HasForeignKey(x => x.JobOfferId)
               .OnDelete(DeleteBehavior.Cascade);

        // Recommandé : 1 candidature max par candidat et par offre
        builder.HasIndex(x => new { x.JobOfferId, x.CandidateUserId }).IsUnique();
    }
}
