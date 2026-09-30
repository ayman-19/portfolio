using Portfolio.Web.Entities.Base;

namespace Portfolio.Web.Interfaces.Repositories.Base;

public interface IRepository<T>
    where T : Entity
{
    Task<T?> GetById(long id, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetList(CancellationToken cancellationToken = default);
    Task Add(T entity, CancellationToken cancellationToken = default);
    void Update(T entity);
    void Delete(T entity);
}
