namespace APIs.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task AddRangeAsync(ICollection<T> values);
    }
}
