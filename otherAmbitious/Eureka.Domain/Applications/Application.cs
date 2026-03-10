using Eureka.Domain.Candidates;
using Eureka.Domain.Offers;
using Eureka.Domain.Users;
using System;
using System.Collections.Generic;

namespace Eureka.Domain.Applications;

public sealed class Application
{
    public Guid Id { get; set; }

    public Guid JobOfferId { get; set; }
    public JobOffer JobOffer { get; set; } = null!;

    public Guid CandidateUserId { get; set; }
    public CandidateProfile CandidateProfile { get; set; } = null!;

    public string? Message { get; set; }
    public ApplicationStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<ApplicationDocument> Documents { get; set; } = new List<ApplicationDocument>();
}
