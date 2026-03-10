using Eureka.Domain.Applications;
using Eureka.Domain.Candidates;
using Eureka.Domain.Companies;
using Eureka.Domain.Offers;
using Eureka.Domain.Shared;
using Eureka.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;

namespace Eureka.Persistence;

public sealed class EurekaDbContext : DbContext
{
    public EurekaDbContext(DbContextOptions<EurekaDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();

    public DbSet<CandidateProfile> CandidateProfiles => Set<CandidateProfile>();
    public DbSet<CandidateDocument> CandidateDocuments => Set<CandidateDocument>();
    public DbSet<CandidateActivityDomain> CandidateActivityDomains => Set<CandidateActivityDomain>();

    public DbSet<ActivityDomain> ActivityDomains => Set<ActivityDomain>();

    public DbSet<Company> Companies => Set<Company>();
    public DbSet<CompanyUser> CompanyUsers => Set<CompanyUser>();
    public DbSet<CompanyNeed> CompanyNeeds => Set<CompanyNeed>();

    public DbSet<JobOffer> JobOffers => Set<JobOffer>();
    public DbSet<JobOfferActivityDomain> JobOfferActivityDomains => Set<JobOfferActivityDomain>();

    public DbSet<Eureka.Domain.Applications.Application> Applications => Set<Eureka.Domain.Applications.Application>();
    public DbSet<ApplicationDocument> ApplicationDocuments => Set<ApplicationDocument>();

    public DbSet<InternalNote> InternalNotes => Set<InternalNote>();
    public DbSet<StatusHistory> StatusHistory => Set<StatusHistory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Applique automatiquement toutes les configurations IEntityTypeConfiguration<T>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EurekaDbContext).Assembly);
    }
}
