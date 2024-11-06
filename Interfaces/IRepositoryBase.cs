using System.Linq.Expressions;

namespace Aestus.API.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<List<T>> FindAllAsync(bool trackChanges);
        Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression,
        bool trackChanges);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteByIdAsync(int id);
        Task<T?> GetAsync(int id);
        Task<bool> Exists(int id);
    }
}
