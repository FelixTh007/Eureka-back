using Eureka.Domain.Candidates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eureka.Persistence.Configurations;

public sealed class CandidateProfileConfiguration : IEntityTypeConfiguration<CandidateProfile>
{
    public void Configure(EntityTypeBuilder<CandidateProfile> builder)
    {
        builder.ToTable("CandidateProfiles");

        builder.HasKey(x => x.UserId); // PK = UserId

        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Phone).IsRequired().HasMaxLength(30);
        builder.Property(x => x.Commune).HasMaxLength(100);
        builder.Property(x => x.Summary).HasMaxLength(1000);

        builder.HasOne(x => x.User)
               .WithOne(u => u.CandidateProfile)
               .HasForeignKey<CandidateProfile>(x => x.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
