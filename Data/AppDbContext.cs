using Microsoft.EntityFrameworkCore;
using Eureka.Models;

namespace Eureka.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Actualite> Actualites => Set<Actualite>();
    public DbSet<ActualiteImage> ActualiteImages => Set<ActualiteImage>();
    public DbSet<Candidate> Candidates => Set<Candidate>();
}



