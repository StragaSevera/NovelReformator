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
        Task Update(int id, T model);
        void Remove(T model);
        Task Remove(int id);
    }
}