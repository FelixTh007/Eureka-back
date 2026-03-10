using System;
using Eureka.Domain.Shared;

namespace Eureka.Domain.Candidates;

public sealed class CandidateActivityDomain
{
    public Guid CandidateUserId { get; set; }
    public CandidateProfile CandidateProfile { get; set; } = null!;

    public Guid ActivityDomainId { get; set; }
    public ActivityDomain ActivityDomain { get; set; } = null!;

    public DateTime CreatedAt { get; set; }


}
