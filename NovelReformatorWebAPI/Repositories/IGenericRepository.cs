using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace NovelReformatorWebAPI.Repositories
{
    public interface IGenericRepository<T>
        where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<int> SaveAsync();
        bool HasChanges();
        void Add(T model);
        void Remove(T model);
    }
}