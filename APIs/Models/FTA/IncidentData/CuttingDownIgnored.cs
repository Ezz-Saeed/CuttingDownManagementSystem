using System.ComponentModel.DataAnnotations;

namespace APIs.Models.FTA.IncidentData
{
    public class CuttingDownIgnored
    {
        [Key]
        public int CuttingDownIgnoredKey { get; set; }
        public int CuttingDownIncidentId { get; set; }

        public DateTime ActualCreateDate { get; set; }
        public DateTime? SynchCreateDate { get; set; }

        public string? CabelName { get; set; }
        public string? CabinName { get; set; }

        public string CreatedUser { get; set; }
    }
}
