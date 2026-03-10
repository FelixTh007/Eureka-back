using Eureka.Domain.Applications;
using System;
using System.Collections.Generic;

namespace Eureka.Domain.Candidates;

public sealed class CandidateDocument
{
    public Guid Id { get; set; }

    public Guid CandidateUserId { get; set; }
    public CandidateProfile CandidateProfile { get; set; } = null!;

    public DocumentType Type { get; set; }

    public string? Title { get; set; }
    public string FileName { get; set; } = null!;
    public string MimeType { get; set; } = null!;
    public int FileSize { get; set; }
    public string StorageUrl { get; set; } = null!;

    public bool IsDefault { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<ApplicationDocument> ApplicationDocuments { get; set; }
         = new List<ApplicationDocument>();
}
