using Portfolio.Web.Dtos;
using Portfolio.Web.Interfaces;
using Portfolio.Web.Interfaces.Services;
using Portfolio.Web.Mappers;
using Portfolio.Web.SharedKernel.Primitives;

namespace Portfolio.Web.Implementations.Services;

public class PersonalInfoService(IUnitOfWork unitOfWork) : IPersonalInfoService
{
    public async Task<Result<PersonalInfoDto>> Get(CancellationToken cancellationToken = default)
    {
        var entity = await unitOfWork.PersonalInfo.Get(cancellationToken);
        if (entity is null)
            return Result.Failure<PersonalInfoDto>([Error.NotFound]);
        return Result.Success(entity.ToDto());
    }

    public async Task<Result> Upsert(
        PersonalInfoDto personalInfo,
        CancellationToken cancellationToken = default
    )
    {
        await unitOfWork.PersonalInfo.Upsert(personalInfo.ToEntity(), cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
