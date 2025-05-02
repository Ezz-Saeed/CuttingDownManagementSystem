using APIs.Models.STA.IncidentsAndProblems;

namespace APIs.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<CuttingDownA> CuttingDownAIncidents { get; }
        IRepository<CuttingDownB> CuttingDownBIncidents { get; }
        Task<int> SaveChangesAsync();
    }
}
