using APIs.Models.STA.Structure;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models.STA.IncidentsAndProblems
{
    public class CuttingDownA : CuttingDown
    {
        public string? CuttingDownCabinName { get; set; }
        [ForeignKey(nameof(Cabin))]
        public int? CuttingDownCabinKey { get; set; }
        public virtual Cabin? Cabin { get; set; }
    }
}
