using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        public void Remove(TEntity model)
        {
            Context.Set<TEntity>().Remove(model);
        }
    }
}