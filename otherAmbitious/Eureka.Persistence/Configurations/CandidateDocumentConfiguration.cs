using Eureka.Domain.Candidates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eureka.Persistence.Configurations;

public sealed class CandidateDocumentConfiguration : IEntityTypeConfiguration<CandidateDocument>
{
    public void Configure(EntityTypeBuilder<CandidateDocument> builder)
    {
        builder.ToTable("CandidateDocuments");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FileName).IsRequired().HasMaxLength(255);
        builder.Property(x => x.MimeType).IsRequired().HasMaxLength(100);
        builder.Property(x => x.StorageUrl).IsRequired().HasMaxLength(2000);

        builder.HasOne(x => x.CandidateProfile)
               .WithMany(cp => cp.Documents)
               .HasForeignKey(x => x.CandidateUserId)
               .OnDelete(DeleteBehavior.Cascade);

        // Optionnel: éviter plusieurs "default" du même type
        // builder.HasIndex(x => new { x.CandidateUserId, x.Type, x.IsDefault });
    }
}
