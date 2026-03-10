using Eureka.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eureka.Persistence.Configurations;

public sealed class StatusHistoryConfiguration : IEntityTypeConfiguration<StatusHistory>
{
    public void Configure(EntityTypeBuilder<StatusHistory> b)
    {
        b.ToTable("status_history");

        b.HasKey(x => x.Id);

        b.Property(x => x.EntityType)
            .HasConversion<string>()
            .HasMaxLength(30)
            .IsRequired();

        b.Property(x => x.FromStatus).HasMaxLength(30);
        b.Property(x => x.ToStatus).HasMaxLength(30).IsRequired();

        b.Property(x => x.ChangedAt).IsRequired();

        b.HasOne(x => x.ChangedByUser)
            .WithMany(x => x.StatusChanges)
            .HasForeignKey(x => x.ChangedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasIndex(x => new { x.EntityType, x.EntityId, x.ChangedAt });
    }
}
