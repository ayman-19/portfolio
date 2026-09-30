using Microsoft.EntityFrameworkCore.Storage;
using Portfolio.Web.Interfaces.Repositories;

namespace Portfolio.Web.Interfaces;

public interface IUnitOfWork : IAsyncDisposable, IDisposable
{
    IPersonalInfoRepository PersonalInfo { get; }
    IEducationRepository Education { get; }
    IExperienceRepository Experiences { get; }
    ISkillRepository Skills { get; }

    Task<IDbContextTransaction> BeginTransactionAsync(
        CancellationToken cancellationToken = default
    );
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
