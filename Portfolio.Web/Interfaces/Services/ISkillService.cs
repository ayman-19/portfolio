using Portfolio.Web.Dtos;
using Portfolio.Web.SharedKernel.Primitives;

namespace Portfolio.Web.Interfaces.Services;

public interface ISkillService
{
    Task<Result<SkillDto>> GetById(long id, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<SkillDto>>> GetList(CancellationToken cancellationToken = default);
    Task<Result> Add(SkillDto skill, CancellationToken cancellationToken = default);
    Task<Result> Update(SkillDto skill, CancellationToken cancellationToken = default);
    Task<Result> Delete(long id, CancellationToken cancellationToken = default);
}
