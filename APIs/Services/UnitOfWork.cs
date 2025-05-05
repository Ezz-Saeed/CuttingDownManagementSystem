using APIs.Data;
using APIs.Interfaces;
using APIs.Models.FTA.Hierarchy;
using APIs.Models.FTA.IncidentData;
using APIs.Models.STA.IncidentsAndProblems;
using APIs.Models.STA.Structure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Channel = APIs.Models.FTA.Hierarchy.Channel;

namespace APIs.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
            CuttingDownAIncidents = new Repository<CuttingDownA>(context);
            CuttingDownBIncidents = new Repository<CuttingDownB>(context);
            Cabins = new Repository<Cabin>(context);
            Cables = new Repository<Cable>(context);
            IgnoredIncidents = new Repository<CuttingDownIgnored>(context);
            Headers = new  Repository<CuttingDownHeader>(context);
            Channels = new  Repository<Channel>(context);
            ProblemTypes = new  Repository<ProblemType>(context);
            NetworkElements = new Repository<NetworkElement>(context);
            CuttingDownDetails = new Repository<CuttingDownDetail>(context);
            NetworkElementHierarchyPaths = new Repository<NetworkElementHierarchyPath>(context);
        }
        public IRepository<CuttingDownA> CuttingDownAIncidents {  get; private set; }

        public IRepository<CuttingDownB> CuttingDownBIncidents { get; private set; }

        public IRepository<Cabin> Cabins { get; private set; }

        public IRepository<Cable> Cables { get; private set; }

        public IRepository<CuttingDownIgnored> IgnoredIncidents { get; private set; }

        public IRepository<CuttingDownHeader> Headers { get; private set; }

        public IRepository<Channel> Channels { get; private set; }

        public IRepository<ProblemType> ProblemTypes { get; private set; }

        public IRepository<NetworkElement> NetworkElements { get; private set; }

        public IRepository<CuttingDownDetail> CuttingDownDetails { get; private set; }

        public IRepository<NetworkElementHierarchyPath> NetworkElementHierarchyPaths { get; private set; }

        public async Task<int> GetImpactedCustomerCount(int id)
        {
            var param = new SqlParameter("@NetworkElementKey", id);

            var result = await context
                .Database
                .SqlQueryRaw<int>("SELECT dbo.FN_GetAffectedCustomerCount(@NetworkElementKey) AS Value", param)
                .FirstAsync();

            return result;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
