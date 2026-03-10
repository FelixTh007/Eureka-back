using System;
using System.Collections.Generic;
using Eureka.Domain.Offers;

namespace Eureka.Domain.Companies;

public sealed class Company
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
    public string? Siret { get; set; } // optionnel V1

    public string? Sector { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<CompanyUser> Users { get; set; } = new List<CompanyUser>();
    public ICollection<CompanyNeed> Needs { get; set; } = new List<CompanyNeed>();
    public ICollection<JobOffer> JobOffers { get; set; } = new List<JobOffer>();
}
