using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIs.Models.STA.IncidentsAndProblems
{
    public class ProblemType
    {
        [Key]
        public int ProblemTypeKey { get; set; }
        public string ProblemTypeName { get; set; }
        [JsonIgnore]
        public virtual ICollection<CuttingDownA> CuttingDownAIncidents { get; set; }
        [JsonIgnore]
        public virtual ICollection<CuttingDownB> CuttingDownBIncidents { get; set; }
    }
}
