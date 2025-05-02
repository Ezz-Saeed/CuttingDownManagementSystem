using System.ComponentModel.DataAnnotations;

namespace APIs.Models.STA.IncidentsAndProblems
{
    public class ProblemType
    {
        [Key]
        public int ProblemTypeKey { get; set; }
        public string ProblemTypeName { get; set; }

        public virtual ICollection<CuttingDownA> CuttingDownAIncidents { get; set; }
        public virtual ICollection<CuttingDownB> CuttingDownBIncidents { get; set; }
    }
}
