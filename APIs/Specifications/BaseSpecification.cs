using System.Linq.Expressions;

namespace APIs.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : class
    {
        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; private set; }

        public List<Expression<Func<T, object>>> Eagers { get; private set; } =
            new List<Expression<Func<T, object>>>();
    }
}
