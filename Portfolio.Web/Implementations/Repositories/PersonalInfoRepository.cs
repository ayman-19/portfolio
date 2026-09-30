using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using Portfolio.Web.Interfaces.Repositories;

namespace Portfolio.Web.Implementations.Repositories;

public class PersonalInfoRepository(PortfolioDbContext context) : IPersonalInfoRepository
{
    private readonly PortfolioDbContext _context = context;

    public async Task<PersonalInfo?> Get(CancellationToken cancellationToken = default)
    {
        return await _context.PersonalInfo.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task Upsert(
        PersonalInfo personalInfo,
        CancellationToken cancellationToken = default
    )
    {
        var existing = await _context.PersonalInfo.FirstOrDefaultAsync(cancellationToken);
        if (existing == null)
        {
            await _context.PersonalInfo.AddAsync(personalInfo, cancellationToken);
        }
        else
        {
            personalInfo.Id = existing.Id;
            _context.Entry(existing).CurrentValues.SetValues(personalInfo);
        }
    }
}
