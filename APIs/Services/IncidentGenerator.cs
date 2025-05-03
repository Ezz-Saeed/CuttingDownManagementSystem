using APIs.Interfaces;
using APIs.Models.STA.IncidentsAndProblems;

namespace APIs.Services
{
    public class IncidentGenerator : IIncidentGenerator
    {
        private readonly Random _rand = new();
        private readonly IUnitOfWork _unitOfWork;
        public IncidentGenerator(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<List<CuttingDownA>> GenerateIncidentA(int count, int closedPercentage)
        {
            List<CuttingDownA> incidents = new List<CuttingDownA>();
            for (int i = 0; i < count;i++)
            {             
                var isClosed = _rand.Next(100) < closedPercentage;
                var createDate = DateTime.UtcNow.AddMinutes(-_rand.Next(10, 500));
                var endDate = isClosed ? createDate.AddMinutes(_rand.Next(10, 300)) : (DateTime?)null;
                var cabinName = $"cab-{_rand.Next(1,4)}-{_rand.Next(1, 4)}";
                var cableKey = await ExtractCabinKey(cabinName) == 0 ? null : ExtractCabinKey(cabinName); 

                incidents.Add
                    (
                        new CuttingDownA
                        {
                            CuttingDownCabinKey = cableKey?.Result,
                            CuttingDownCabinName = cabinName,
                            ProblemTypeKey = _rand.Next(1, 14),
                            CreateDate = createDate,
                            EndDate = endDate,
                            IsPlanned = _rand.Next(2) == 1,
                            IsGlobal = _rand.Next(2) == 1,
                            PlannedStartDTS = _rand.Next(2) == 1 ? createDate.AddMinutes(-_rand.Next(100)) : null,
                            PlannedEndDTS = _rand.Next(2) == 1 ? createDate.AddMinutes(_rand.Next(100, 300)) : null,
                            IsActive = !isClosed,
                            CreatedUser = "SourceA",
                            UpdatedUser = isClosed ? "SourceA" : null
                        }
                    );
            }

            return incidents;
        }

        public async Task<List<CuttingDownB>> GenerateIncidentB(int count, int closedPercentage)
        {
            List<CuttingDownB> incidents = new List<CuttingDownB>();         

            for (int i = 0; i < count;i++)
            {
                var isClosed = _rand.Next(100) < closedPercentage;
                var createDate = DateTime.UtcNow.AddMinutes(-_rand.Next(10, 500));
                var endDate = isClosed ? createDate.AddMinutes(_rand.Next(10, 300)) : (DateTime?)null;
                var cableName = $"ch-{_rand.Next(1, 4)}-{_rand.Next(1, 4)}";
                var cabinKey = await ExtractCableKey(cableName) == 0 ? null : ExtractCableKey(cableName);
                incidents.Add
                    (
                        new CuttingDownB
                        {
                            CuttingDownCableKey = cabinKey?.Result,
                            CuttingDownCableName = cableName,
                            ProblemTypeKey = _rand.Next(1, 14),
                            CreateDate = createDate,
                            EndDate = endDate,
                            IsPlanned = _rand.Next(2) == 1,
                            IsGlobal = _rand.Next(2) == 1,
                            PlannedStartDTS = _rand.Next(2) == 1 ? createDate.AddMinutes(-_rand.Next(100)) : null,
                            PlannedEndDTS = _rand.Next(2) == 1 ? createDate.AddMinutes(_rand.Next(100, 300)) : null,
                            IsActive = !isClosed,
                            CreatedUser = "SourceB",
                            UpdatedUser = isClosed ? "SourceB" : null
                        }
                    );
            }
            return incidents;
        }

        private async Task<int> ExtractCabinKey(string name)
        {
            var cabin = await _unitOfWork.Cabins.GetEntityAsync(c=>c.CabinName == name);
            return cabin == null ? 0 : cabin.CabinKey;
        }

        private async Task<int> ExtractCableKey(string name)
        {
            var cable = await _unitOfWork.Cables.GetEntityAsync(c => c.CableName == name);
            return cable == null ? 0 : cable.CableKey;
        }
    }
}
