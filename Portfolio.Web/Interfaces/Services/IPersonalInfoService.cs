using Portfolio.Web.Dtos;
using Portfolio.Web.SharedKernel.Primitives;

namespace Portfolio.Web.Interfaces.Services;

public interface IPersonalInfoService
{
    Task<Result<PersonalInfoDto>> Get(CancellationToken cancellationToken = default);
    Task<Result> Upsert(PersonalInfoDto personalInfo, CancellationToken cancellationToken = default);
}
