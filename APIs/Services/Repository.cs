using APIs.Data;
using APIs.Interfaces;
using APIs.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace APIs.Services
{
    public class Repository<T>(AppDbContext context) : IRepository<T> where T : class
    {
        public async Task AddRangeAsync(ICollection<T> values)
        {
            await context.Set<T>().AddRangeAsync(values);
        }

        public async Task<T> GetEntityAsync(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<ICollection<T>> GetAllAsync(ISpecification<T>? specification)
        {
            if(specification is not null)
                return await ApplySpecification(specification).ToListAsync();
            return await context.Set<T>().ToListAsync();
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(context.Set<T>().AsQueryable(), specification);
        }

        //public T Create(T entity)
        //{
        //    context.Set<T>().Add(entity);
        //    return entity;
        //}

        //public async Task<T> FindAsync(Expression<Func<T, bool>> predicate, params string[]? eagers)
        //{
        //    IQueryable<T> query = context.Set<T>();
        //    if (eagers is not null && eagers.Length > 0)
        //    {
        //        foreach (var eager in eagers)
        //            query = query.Include(eager);
        //    }

        //    return await query.SingleOrDefaultAsync(predicate);
        //}

        //public async Task<IReadOnlyList<T>> GetAllAsync(ISpecification<T>? specification)
        //{
        //    if (specification is not null)
        //        return await ApplySpecification(specification).ToListAsync();
        //    return await context.Set<T>().ToListAsync();
        //}

        //public void Delete(T entity)
        //{
        //    context.Set<T>().Remove(entity);
        //}

        //public void Update(T entity)
        //{
        //    context.Set<T>().Update(entity);
        //}

        //public async Task<int> CountAsync(ISpecification<T> specification)
        //{
        //    return await ApplySpecification(specification).CountAsync();
        //}

        //private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        //{
        //    return SpecificationEvaluator<T>.GetQuery(context.Set<T>().AsQueryable(), specification);
        //}

    }
}
