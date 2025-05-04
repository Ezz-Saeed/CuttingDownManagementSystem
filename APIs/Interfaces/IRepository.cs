using System.Linq.Expressions;

namespace APIs.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task AddRangeAsync(ICollection<T> values);
        Task<T> GetEntityAsync(Expression<Func<T,bool>> expression);
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? expression);
        void Delete(T entity);
    }
}
