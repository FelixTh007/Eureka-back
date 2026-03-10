using System;
using System.Collections.Generic;
using Eureka.Domain.Users;

namespace Eureka.Domain.Companies;

public sealed class CompanyUser
{
    public Guid Id { get; set; }

    public Guid CompanyId { get; set; }
    public Company Company { get; set; } = default!;

    public Guid UserId { get; set; }
    public User User { get; set; } = default!;

    public CompanyUserRole CompanyRole { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<CompanyNeed> CreatedNeeds { get; set; } = new List<CompanyNeed>();
}
