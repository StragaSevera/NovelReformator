using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NovelReformatorWebAPI.Utils;

namespace NovelReformatorWebAPI.Repositories
{
    public abstract class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        protected GenericRepository(TContext context)
        {
            Context = context;
        }

        protected TContext Context { get; }

        public virtual Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            // Почему-то не работает контравариантность при простом возврате без await
            // используем удобный Extension Method
            return Context.Set<TEntity>().ToListAsync().AsTask<List<TEntity>, IReadOnlyList<TEntity>>();
        }

        public virtual Task<TEntity> GetByIdAsync(int id)
        {
            return Context.Set<TEntity>().FindAsync(id);
        }

        public Task<int> SaveAsync()
        {
            return Context.SaveChangesAsync();
        }

        public bool HasChanges()
        {
            return Context.ChangeTracker.HasChanges();
        }

        public void Add(TEntity model)
        {
            Context.Set<TEntity>().Add(model);
        }

        public async Task Update(int id, TEntity model)
        {
            var currentModel = await GetByIdAsync(id);
            Context.Entry(currentModel).CurrentValues.SetValues(model);
        }

        public void Remove(TEntity model)
        {
            Context.Set<TEntity>().Remove(model);
        }

        public async Task Remove(int id)
        {
            Remove(await GetByIdAsync(id));
        }
    }
}