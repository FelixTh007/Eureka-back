using System;
using Eureka.Domain.Shared;

namespace Eureka.Domain.Offers;

public sealed class JobOfferActivityDomain
{
    public Guid JobOfferId { get; set; }
    public JobOffer JobOffer { get; set; } = default!;

    public Guid ActivityDomainId { get; set; }
    public ActivityDomain ActivityDomain { get; set; } = default!;

    public DateTime CreatedAt { get; set; }
}
