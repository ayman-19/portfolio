using Portfolio.Web.Dtos;
using Portfolio.Web.Interfaces;
using Portfolio.Web.Interfaces.Services;
using Portfolio.Web.Mappers;
using Portfolio.Web.SharedKernel.Primitives;

namespace Portfolio.Web.Implementations.Services;

public class SkillService(IUnitOfWork unitOfWork) : ISkillService
{
    public async Task<Result<SkillDto>> GetById(
        long id,
        CancellationToken cancellationToken = default
    )
    {
        var entity = await unitOfWork.Skills.GetById(id, cancellationToken);
        if (entity is null)
            return Result.Failure<SkillDto>([Error.NotFound]);
        return Result.Success(entity.ToDto());
    }

    public async Task<Result<IEnumerable<SkillDto>>> GetList(
        CancellationToken cancellationToken = default
    )
    {
        var entities = await unitOfWork.Skills.GetList(cancellationToken);
        return Result.Success(entities.Select(e => e.ToDto()));
    }

    public async Task<Result> Add(SkillDto skill, CancellationToken cancellationToken = default)
    {
        await unitOfWork.Skills.Add(skill.ToEntity(), cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

    public async Task<Result> Update(SkillDto skill, CancellationToken cancellationToken = default)
    {
        unitOfWork.Skills.Update(skill.ToEntity());
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

    public async Task<Result> Delete(long id, CancellationToken cancellationToken = default)
    {
        var skill = await unitOfWork.Skills.GetById(id, cancellationToken);
        if (skill == null)
            return Result.Failure([Error.NotFound]);

        unitOfWork.Skills.Delete(skill);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
