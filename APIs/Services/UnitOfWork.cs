using APIs.Data;
using APIs.Interfaces;
using APIs.Models.STA.IncidentsAndProblems;
using APIs.Models.STA.Structure;

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
        }
        public IRepository<CuttingDownA> CuttingDownAIncidents {  get; private set; }

        public IRepository<CuttingDownB> CuttingDownBIncidents { get; private set; }

        public IRepository<Cabin> Cabins { get; private set; }

        public IRepository<Cable> Cables { get; private set; }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
