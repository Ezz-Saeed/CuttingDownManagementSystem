using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models.FTA.IncidentData
{
    public class CuttingDownDetail
    {
        [Key]
        public int CuttingDownDetailKey { get; set; }

        [ForeignKey(nameof(CuttingDownHeader))]
        public int CuttingDownKey { get; set; }
        public virtual CuttingDownHeader CuttingDownHeader { get; set; }

        public int NetworkElementKey { get; set; }

        public DateTime ActualCreateDate { get; set; }
        public DateTime? ActualEndDate { get; set; }

        public int ImpactedCustomers { get; set; }
    }
}
