using APIs.Models.FTA.IncidentData;
using APIs.Models.STA.IncidentsAndProblems;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.DTOs
{
    public class GetHeaderDto
    {
        public int CuttingDownKey { get; set; }
        public int CuttingDownIncidentId { get; set; }
        public int ChannelKey { get; set; }
        public int CuttingDownProblemTypeKey { get; set; }

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

    }
}
