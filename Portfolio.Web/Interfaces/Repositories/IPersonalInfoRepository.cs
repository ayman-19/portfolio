using Portfolio.Web.Entities;

namespace Portfolio.Web.Interfaces.Repositories;

public interface IPersonalInfoRepository
{
    Task<PersonalInfo?> Get(CancellationToken cancellationToken = default);
    Task Upsert(PersonalInfo personalInfo, CancellationToken cancellationToken = default);
}
