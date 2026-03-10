using System;
using System.Collections.Generic;
using Eureka.Domain.Candidates;
using Eureka.Domain.Offers;

namespace Eureka.Domain.Shared;

public sealed class ActivityDomain
{
    public Guid Id { get; set; }

    // Ex: BTP, RESTAURATION, NETTOYAGE...
    public string Code { get; set; } = null!;
    public string Label { get; set; } = null!;
    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<CandidateActivityDomain> Candidates { get; set; } = new List<CandidateActivityDomain>();
    public ICollection<JobOfferActivityDomain> JobOffers { get; set; } = new List<JobOfferActivityDomain>();
}
