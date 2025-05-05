using APIs.Models.FTA;
using APIs.Models.FTA.Hierarchy;
using APIs.Models.FTA.IncidentData;
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
        IRepository<CuttingDownIgnored> IgnoredIncidents { get; }
        IRepository<CuttingDownHeader> Headers { get; }
        IRepository<Channel> Channels { get; }
        IRepository<ProblemType> ProblemTypes { get; }
        IRepository<NetworkElement> NetworkElements { get; }
        IRepository<CuttingDownDetail> CuttingDownDetails { get; }
        IRepository<NetworkElementHierarchyPath> NetworkElementHierarchyPaths { get; }
        IRepository<User> Users { get; }
        Task<int> GetImpactedCustomerCount(int id);
        Task<int> SaveChangesAsync();
    }
}
