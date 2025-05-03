using APIs.Models.STA.IncidentsAndProblems;

namespace APIs.Interfaces
{
    public interface IIncidentGenerator
    {
        Task<List<CuttingDownA>> GenerateIncidentA(int count, int closedPercentage);
        Task<List<CuttingDownB>> GenerateIncidentB(int count, int closedPercentage);
    }
}
