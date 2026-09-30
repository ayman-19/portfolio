using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using Portfolio.Web.Interfaces.Repositories;

namespace Portfolio.Web.Implementations.Repositories;

public class EducationRepository(PortfolioDbContext context) : IEducationRepository
{
    private readonly PortfolioDbContext _context = context;

    public async Task<Education?> Get(CancellationToken cancellationToken = default)
    {
        return await _context.Education.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task Upsert(Education education, CancellationToken cancellationToken = default)
    {
        var existing = await _context.Education.FirstOrDefaultAsync(cancellationToken);
        if (existing == null)
        {
            await _context.Education.AddAsync(education, cancellationToken);
        }
        else
        {
            education.Id = existing.Id;
            _context.Entry(existing).CurrentValues.SetValues(education);
        }
    }
}
