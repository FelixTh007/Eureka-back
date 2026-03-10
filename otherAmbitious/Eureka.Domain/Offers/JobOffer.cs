using Eureka.Domain.Applications;
using Eureka.Domain.Companies;
using Eureka.Domain.Users;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Eureka.Domain.Offers;

public sealed class JobOffer
{
    public Guid Id { get; set; }

    public Guid CompanyNeedId { get; set; }
    public CompanyNeed CompanyNeed { get; set; } = default!;

    public Guid CompanyId { get; set; }
    public Company Company { get; set; } = default!;

    public Guid CreatedByCounselorUserId { get; set; }
    public User CreatedByCounselorUser { get; set; } = default!;

    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string? ContractType { get; set; }
    public string? Location { get; set; }
    public string? SalaryRange { get; set; }

    public OfferStatus Status { get; set; }
    public DateTime? PublishedAt { get; set; }
    public DateTime? ClosedAt { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<Applications.Application> Applications { get; set; } = new List<Applications.Application>();

    // Domaines liés à l’offre
    public ICollection<JobOfferActivityDomain> ActivityDomains { get; set; } = new List<JobOfferActivityDomain>();
}
