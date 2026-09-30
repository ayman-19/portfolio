using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Context;

public class PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : DbContext(options)
{
    public DbSet<PersonalInfo> PersonalInfo { get; set; } = null!;
    public DbSet<Experience> Experiences { get; set; } = null!;
    public DbSet<Skill> Skills { get; set; } = null!;
    public DbSet<Education> Education { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
