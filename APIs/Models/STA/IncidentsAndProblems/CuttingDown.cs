using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models.STA.IncidentsAndProblems
{
    public class CuttingDown
    {
        [Key]
        public int CuttingDownIncidentId { get; set; }
        //public string CuttingDownCableName { get; set; }
        [ForeignKey(nameof(ProblemType))]
        public int ProblemTypeKey { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsPlanned { get; set; }
        public bool IsGlobal { get; set; }

        public DateTime? PlannedStartDTS { get; set; }
        public DateTime? PlannedEndDTS { get; set; }

        public bool IsActive { get; set; }
        public string CreatedUser { get; set; }
        public string? UpdatedUser { get; set; }

        public virtual ProblemType ProblemType { get; set; }
    }
}
