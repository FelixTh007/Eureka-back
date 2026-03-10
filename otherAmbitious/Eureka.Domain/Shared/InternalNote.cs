using System;
using Eureka.Domain.Users;

namespace Eureka.Domain.Shared;

public sealed class InternalNote
{
    public Guid Id { get; set; }

    public NoteEntityType EntityType { get; set; }
    public Guid EntityId { get; set; }

    public Guid AuthorUserId { get; set; }
    public User AuthorUser { get; set; } = default!;

    public string Content { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
}
