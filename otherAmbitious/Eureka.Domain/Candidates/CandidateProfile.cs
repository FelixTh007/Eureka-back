using System;
using System.Collections.Generic;
using Eureka.Domain.Shared;
using Eureka.Domain.Users;

namespace Eureka.Domain.Candidates;

public sealed class CandidateProfile
{
    // PK = UserId (1-1)
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string? Commune { get; set; }
    public string? Summary { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<CandidateDocument> Documents { get; set; } = new List<CandidateDocument>();

    // Domaines d’intérêt (many-to-many via table de liaison)
    public ICollection<CandidateActivityDomain> ActivityDomains { get; set; } = new List<CandidateActivityDomain>();

    public ICollection<Eureka.Domain.Applications.Application> Applications { get; set; } = new List<Eureka.Domain.Applications.Application>();
}
