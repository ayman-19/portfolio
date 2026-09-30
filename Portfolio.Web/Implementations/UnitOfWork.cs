using Microsoft.EntityFrameworkCore.Storage;
using Portfolio.Web.Context;
using Portfolio.Web.Implementations.Repositories;
using Portfolio.Web.Interfaces;
using Portfolio.Web.Interfaces.Repositories;

namespace Portfolio.Web.Implementations;

public sealed class UnitOfWork(PortfolioDbContext context) : IUnitOfWork
{
    private IPersonalInfoRepository? _personalInfo;
    public IPersonalInfoRepository PersonalInfo =>
        _personalInfo ??= new PersonalInfoRepository(context);

    private IEducationRepository? _education;
    public IEducationRepository Education => _education ??= new EducationRepository(context);

    private IExperienceRepository? _experiences;
    public IExperienceRepository Experiences => _experiences ??= new ExperienceRepository(context);

    private ISkillRepository? _skills;
    public ISkillRepository Skills => _skills ??= new SkillRepository(context);

    public async Task<IDbContextTransaction> BeginTransactionAsync(
        CancellationToken cancellationToken = default
    ) => await context.Database.BeginTransactionAsync(cancellationToken);

    public void Dispose() => context.Dispose();

    public async ValueTask DisposeAsync() => await context.DisposeAsync();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await context.SaveChangesAsync(cancellationToken);
}
