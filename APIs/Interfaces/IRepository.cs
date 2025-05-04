using APIs.Specifications;
using System.Linq.Expressions;

namespace APIs.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task AddRangeAsync(ICollection<T> values);
        Task AddEntity(T entity);
        Task<T> GetEntityAsync(Expression<Func<T,bool>> expression);
        Task<ICollection<T>> GetAllAsync(ISpecification<T>? specification);
        Task<ICollection<T>> GetAllAsyncWithExp(Expression<Func<T,bool>>? expression);
        void UpdateEntity(T entity);
        void Delete(T entity);
    }
}
