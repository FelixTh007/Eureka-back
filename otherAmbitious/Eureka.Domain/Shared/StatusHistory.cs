using System;
using Eureka.Domain.Users;

namespace Eureka.Domain.Shared;

public sealed class StatusHistory
{
    public Guid Id { get; set; }

    public HistoryEntityType EntityType { get; set; }
    public Guid EntityId { get; set; }

    public string? FromStatus { get; set; }
    public string ToStatus { get; set; } = default!;

    public Guid ChangedByUserId { get; set; }
    public User ChangedByUser { get; set; } = default!;

    public DateTime ChangedAt { get; set; }
}
