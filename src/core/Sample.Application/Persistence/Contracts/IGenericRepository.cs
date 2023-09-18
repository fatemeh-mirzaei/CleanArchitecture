using Sample.Domain;

namespace Sample.Application.Persistence.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class, IBaseDomainEntity
    {
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }
        void Add(TEntity entity);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
        void DeleteRange(IEnumerable<TEntity> entities);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation);
        TEntity GetById(params object[] ids);
        Task<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
