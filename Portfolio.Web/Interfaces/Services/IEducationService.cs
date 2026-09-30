using Portfolio.Web.Dtos;
using Portfolio.Web.SharedKernel.Primitives;

namespace Portfolio.Web.Interfaces.Services;

public interface IEducationService
{
    Task<Result<EducationDto>> Get(CancellationToken cancellationToken = default);
    Task<Result> Upsert(EducationDto education, CancellationToken cancellationToken = default);
}
