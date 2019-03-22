using System.Collections.Generic;
using System.Threading.Tasks;

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
        Task UpdateAsync(int id, T model);
        Task RemoveAsync(int id);
    }
}