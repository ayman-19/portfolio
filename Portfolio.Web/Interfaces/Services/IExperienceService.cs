using Portfolio.Web.Dtos;
using Portfolio.Web.SharedKernel.Primitives;

namespace Portfolio.Web.Interfaces.Services;

public interface IExperienceService
{
    Task<Result<ExperienceDto>> GetById(long id, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<ExperienceDto>>> GetList(CancellationToken cancellationToken = default);
    Task<Result> Add(ExperienceDto experience, CancellationToken cancellationToken = default);
    Task<Result> Update(ExperienceDto experience, CancellationToken cancellationToken = default);
    Task<Result> Delete(long id, CancellationToken cancellationToken = default);
}
