using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Context;
using Portfolio.Web.Entities.Base;
using Portfolio.Web.Interfaces.Repositories.Base;

namespace Portfolio.Web.Implementations.Repositories.Base;

public class Repository<T>(PortfolioDbContext context) : IRepository<T>
    where T : Entity
{
    protected readonly PortfolioDbContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();

    public virtual async Task<T?> GetById(long id, CancellationToken cancellationToken = default) =>
        await _dbSet.FindAsync([id], cancellationToken);

    public virtual async Task<IEnumerable<T>> GetList(
        CancellationToken cancellationToken = default
    ) => await _dbSet.ToListAsync(cancellationToken);

    public virtual async Task Add(T entity, CancellationToken cancellationToken = default) =>
        await _dbSet.AddAsync(entity, cancellationToken);

    public virtual void Update(T entity) => _dbSet.Update(entity);

    public virtual void Delete(T entity) => _dbSet.Remove(entity);
}
