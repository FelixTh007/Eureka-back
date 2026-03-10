using Eureka.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eureka.Persistence.Configurations;

public sealed class InternalNoteConfiguration : IEntityTypeConfiguration<InternalNote>
{
    public void Configure(EntityTypeBuilder<InternalNote> b)
    {
        b.ToTable("internal_notes");

        b.HasKey(x => x.Id);

        b.Property(x => x.EntityType)
            .HasConversion<string>()
            .HasMaxLength(30)
            .IsRequired();

        b.Property(x => x.Content).IsRequired();
        b.Property(x => x.CreatedAt).IsRequired();

        b.HasOne(x => x.AuthorUser)
            .WithMany(x => x.InternalNotesAuthored)
            .HasForeignKey(x => x.AuthorUserId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasIndex(x => new { x.EntityType, x.EntityId, x.CreatedAt });
        b.HasIndex(x => new { x.AuthorUserId, x.CreatedAt });
    }
}
