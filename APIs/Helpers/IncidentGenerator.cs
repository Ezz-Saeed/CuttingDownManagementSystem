using APIs.Models.STA.IncidentsAndProblems;

namespace APIs.Helpers
{
    public static class IncidentGenerator
    {
        private static readonly Random _rand = new();

        public static List<CuttingDownA> GenerateIncidentA(int count, int closedPercentage)
        {
            List<CuttingDownA> incidents = new List<CuttingDownA>();
            var isClosed = _rand.Next(100) < closedPercentage;
            var createDate = DateTime.UtcNow.AddMinutes(-_rand.Next(10, 500));
            var endDate = isClosed ? createDate.AddMinutes(_rand.Next(10, 300)) : (DateTime?)null;

            for(int i = 0; i < count;)
            {
                incidents.Add
                    (
                        new CuttingDownA
                        {
                            CuttingDownCabinName = $"Cabin-{_rand.Next(1, 20)}-{_rand.Next(1, 20)}",
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

        public static List<CuttingDownB>GenerateIncidentB(int count, int closedPercentage)
        {
            List<CuttingDownB> incidents = new List<CuttingDownB>();
            var isClosed = _rand.Next(100) < closedPercentage;
            var createDate = DateTime.UtcNow.AddMinutes(-_rand.Next(10, 500));
            var endDate = isClosed ? createDate.AddMinutes(_rand.Next(10, 300)) : (DateTime?)null;

            for (int i = 0; i < count;)
            {
                incidents.Add
                    (
                        new CuttingDownB
                        {
                            CuttingDownCableName = $"Cable-{_rand.Next(1, 20)}-{_rand.Next(1, 20)}",
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
    }
}
