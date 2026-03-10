using System;
using Eureka.Domain.Candidates;

namespace Eureka.Domain.Applications;

public sealed class ApplicationDocument
{
    public Guid Id { get; set; }

    public Guid ApplicationId { get; set; }
    public Application Application { get; set; } = default!;

    public Guid CandidateDocumentId { get; set; }
    public CandidateDocument CandidateDocument { get; set; } = default!;

    public DateTime CreatedAt { get; set; }
}
