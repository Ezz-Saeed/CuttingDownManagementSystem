using System.Linq.Expressions;

namespace APIs.Specifications
{
    public interface ISpecification<T> where T : class
    {
        Expression<Func<T, bool>> Criteria { get; }
    }
}
