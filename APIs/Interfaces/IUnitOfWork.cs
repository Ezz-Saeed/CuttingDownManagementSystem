using APIs.Models.STA.IncidentsAndProblems;
using APIs.Models.STA.Structure;

namespace APIs.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<CuttingDownA> CuttingDownAIncidents { get; }
        IRepository<CuttingDownB> CuttingDownBIncidents { get; }
        IRepository<Cabin> Cabins { get; }
        IRepository<Cable> Cables { get; }
        Task<int> SaveChangesAsync();
    }
}
