using APIs.Models.FTA.Hierarchy;
using APIs.Models.STA.IncidentsAndProblems;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models.FTA.IncidentData
{
    public class CuttingDownHeader
    {
        [Key]
        public int CuttingDownKey { get; set; }
        public int CuttingDownIncidentId { get; set; }

        [ForeignKey(nameof(Channel))]
        public int ChannelKey { get; set; }
        public virtual Channel Channel { get; set; }

        [ForeignKey(nameof(CuttingDownProblemType))]
        public int CuttingDownProblemTypeKey { get; set; }
        public virtual ProblemType CuttingDownProblemType { get; set; } 

        public DateTime ActualCreateDate { get; set; }
        public DateTime? SynchCreateDate { get; set; }
        public DateTime? SynchUpdateDate { get; set; }
        public DateTime? ActualEndDate { get; set; }

        public bool IsPlanned { get; set; }
        public bool IsGlobal { get; set; }

        public DateTime? PlannedStartDTS { get; set; }
        public DateTime? PlannedEndDTS { get; set; }

        public bool IsActive { get; set; }

        public string CreateSystemUserID { get; set; }
        public string? UpdateSystemUserID { get; set; }

        [ForeignKey(nameof(NetworkElementHierarchyPath))]
        public int? HierarchyPathKey { get; set; }
        public virtual NetworkElementHierarchyPath? NetworkElementHierarchyPath { get; set; }

        public virtual ICollection<CuttingDownDetail> Details { get; set; }
    }
}
