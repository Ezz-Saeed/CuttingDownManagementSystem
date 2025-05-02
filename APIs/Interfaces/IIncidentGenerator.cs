using APIs.Models.STA.IncidentsAndProblems;

namespace APIs.Interfaces
{
    public interface IIncidentGenerator
    {
        List<CuttingDownA> GenerateIncidentA(int count, int closedPercentage);
        List<CuttingDownB> GenerateIncidentB(int count, int closedPercentage);
    }
}
