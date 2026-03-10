using System;
using System.Collections.Generic;

namespace Eureka.Domain.Users;

public sealed class Role
{
    public Guid Id { get; set; }

    // Ex: CANDIDATE, COMPANY, COUNSELOR, ADMIN
    public string Code { get; set; } = default!;
    public string Label { get; set; } = default!;

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
