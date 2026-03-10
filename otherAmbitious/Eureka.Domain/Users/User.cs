using Eureka.Domain.Applications;
using Eureka.Domain.Candidates;
using Eureka.Domain.Companies;
using Eureka.Domain.Offers;
using Eureka.Domain.Shared;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Eureka.Domain.Users;

public sealed class User
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation (optionnel au niveau Domain, mais pratique)
    public CandidateProfile? CandidateProfile { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public ICollection<CompanyUser> CompanyUsers { get; set; } = new List<CompanyUser>();

    // Counselor creates offers
    public ICollection<JobOffer> JobOffersCreated { get; set; } = new List<JobOffer>();

    // Candidate submits applications
    public ICollection<Applications.Application> Applications { get; set; } = new List<Applications.Application>();

    public ICollection<InternalNote> InternalNotesAuthored { get; set; } = new List<InternalNote>();
    public ICollection<StatusHistory> StatusChanges { get; set; } = new List<StatusHistory>();
}
