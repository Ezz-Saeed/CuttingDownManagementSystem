using APIs.Models.FTA.Hierarchy;
using APIs.Models.FTA.IncidentData;
using APIs.Models.STA.IncidentsAndProblems;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.DTOs
{
    public class CuttingDownHeaderDto
    {
       
        public int ChannelKey { get; set; }

        public int CuttingDownProblemTypeKey { get; set; }

        public DateTime ActualCreateDate { get; set; }
        public DateTime? SynchCreateDate => ActualCreateDate;

        public string CreateSystemUserID { get; set; } = "Manual";
        public int? HierarchyPathKey { get; set; }

        public List<int> AffectedElements { get; set; } = new List<int>();
    }
}
