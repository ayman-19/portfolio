using Portfolio.Web.Dtos;
using Portfolio.Web.Interfaces;
using Portfolio.Web.Interfaces.Services;
using Portfolio.Web.Mappers;
using Portfolio.Web.SharedKernel.Primitives;

namespace Portfolio.Web.Implementations.Services;

public class EducationService(IUnitOfWork unitOfWork) : IEducationService
{
    public async Task<Result<EducationDto>> Get(CancellationToken cancellationToken = default)
    {
        var entity = await unitOfWork.Education.Get(cancellationToken);
        if (entity is null)
            return Result.Failure<EducationDto>([Error.NotFound]);
        return Result.Success(entity.ToDto());
    }

    public async Task<Result> Upsert(
        EducationDto education,
        CancellationToken cancellationToken = default
    )
    {
        await unitOfWork.Education.Upsert(education.ToEntity(), cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
