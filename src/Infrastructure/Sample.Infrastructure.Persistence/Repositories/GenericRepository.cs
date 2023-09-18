using Microsoft.EntityFrameworkCore;
using Sample.Application.Persistence.Contracts;
using Sample.Domain;
using Sample.Utilities;

namespace Sample.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IBaseDomainEntity
    {
        protected readonly ApplicationDbContext _dbContext;
        public DbSet<TEntity> Entities { get; }
        public virtual IQueryable<TEntity> Table => Entities;
        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Entities = _dbContext.Set<TEntity>();
        }

        #region async Method

        public virtual async Task<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
        {
            return await Entities.FindAsync(ids, cancellationToken);
        }

        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            Assert.NotNull(entity, nameof(entity));
            await Entities.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            Assert.NotNull(entities, nameof(entities));
            await Entities.AddRangeAsync(entities, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            Assert.NotNull(entity, nameof(entity));
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            Assert.NotNull(entity, nameof(entity));
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            Assert.NotNull(entities, nameof(entities));
            _dbContext.Remove(entities);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        #endregion


        #region sync Method

        public virtual TEntity GetById(params object[] ids)
        {
            return Entities.Find(ids);
        }

        public virtual void Add(TEntity entity)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Add(entity);
            _dbContext.SaveChanges();

        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            Assert.NotNull(entities, nameof(entities));
            Entities.AddRange(entities);
            _dbContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            Assert.NotNull(entity, nameof(entity));
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            Assert.NotNull(entity, nameof(entity));
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            Assert.NotNull(entities, nameof(entities));
            _dbContext.Remove(entities);
            _dbContext.SaveChanges();
        }

        #endregion

    }
}
