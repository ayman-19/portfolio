using Portfolio.Web.Dtos;
using Portfolio.Web.Interfaces;
using Portfolio.Web.Interfaces.Services;
using Portfolio.Web.Mappers;
using Portfolio.Web.SharedKernel.Primitives;

namespace Portfolio.Web.Implementations.Services;

public class ExperienceService(IUnitOfWork unitOfWork) : IExperienceService
{
    public async Task<Result<ExperienceDto>> GetById(
        long id,
        CancellationToken cancellationToken = default
    )
    {
        var entity = await unitOfWork.Experiences.GetById(id, cancellationToken);
        if (entity is null)
            return Result.Failure<ExperienceDto>([Error.NotFound]);
        return Result.Success(entity.ToDto());
    }

    public async Task<Result<IEnumerable<ExperienceDto>>> GetList(
        CancellationToken cancellationToken = default
    )
    {
        var entities = await unitOfWork.Experiences.GetList(cancellationToken);
        return Result.Success(entities.Select(e => e.ToDto()));
    }

    public async Task<Result> Add(
        ExperienceDto experience,
        CancellationToken cancellationToken = default
    )
    {
        await unitOfWork.Experiences.Add(experience.ToEntity(), cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

    public async Task<Result> Update(
        ExperienceDto experience,
        CancellationToken cancellationToken = default
    )
    {
        unitOfWork.Experiences.Update(experience.ToEntity());
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

    public async Task<Result> Delete(long id, CancellationToken cancellationToken = default)
    {
        var experience = await unitOfWork.Experiences.GetById(id, cancellationToken);
        if (experience == null)
            return Result.Failure([Error.NotFound]);

        unitOfWork.Experiences.Delete(experience);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
