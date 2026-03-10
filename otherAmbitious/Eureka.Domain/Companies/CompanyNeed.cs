using System;

namespace Eureka.Domain.Companies;

public sealed class CompanyNeed
{
    public Guid Id { get; set; }

    public Guid CompanyId { get; set; }
    public Company Company { get; set; } = default!;

    public Guid CreatedByCompanyUserId { get; set; }
    public CompanyUser CreatedByCompanyUser { get; set; } = default!;

    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string? Location { get; set; }
    public string? Urgency { get; set; }

    public NeedStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // 0..1
    public Eureka.Domain.Offers.JobOffer? JobOffer { get; set; }
}
