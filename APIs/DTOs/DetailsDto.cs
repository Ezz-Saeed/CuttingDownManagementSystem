using APIs.Models.FTA.IncidentData;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.DTOs
{
    public class DetailsDto
    {
        public int CuttingDownDetailKey { get; set; }
        public int IncidentKey { get; set; }

        public int NetworkElementKey { get; set; }
        public string? NetworkElementName { get; set; }
        public int ImpactedCustomers { get; set; }
    }
}
