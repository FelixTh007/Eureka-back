using Eureka.Domain.Applications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eureka.Persistence.Configurations;

public sealed class ApplicationDocumentConfiguration : IEntityTypeConfiguration<ApplicationDocument>
{
    public void Configure(EntityTypeBuilder<ApplicationDocument> builder)
    {
        builder.ToTable("ApplicationDocuments");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Application)
               .WithMany(a => a.Documents)
               .HasForeignKey(x => x.ApplicationId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.CandidateDocument)
               .WithMany(cd => cd.ApplicationDocuments)
               .HasForeignKey(x => x.CandidateDocumentId)
               .OnDelete(DeleteBehavior.Restrict);

        // Optionnel : éviter le même doc deux fois dans la même candidature
        builder.HasIndex(x => new { x.ApplicationId, x.CandidateDocumentId })
               .IsUnique();
    }
}
