using APIs.Models.STA.Structure;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models.STA.IncidentsAndProblems
{
    public class CuttingDownB : CuttingDown
    {
        public string? CuttingDownCableName { get; set; }
        [ForeignKey(nameof(Cable))]
        public int? CuttingDownCableKey { get; set; }
        public virtual Cable? Cable {  get; set; }
    }
}
