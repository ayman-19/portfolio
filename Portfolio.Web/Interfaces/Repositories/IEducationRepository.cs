using Portfolio.Web.Entities;

namespace Portfolio.Web.Interfaces.Repositories;

public interface IEducationRepository
{
    Task<Education?> Get(CancellationToken cancellationToken = default);
    Task Upsert(Education education, CancellationToken cancellationToken = default);
}
