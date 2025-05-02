using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models.STA.Structure
{
    public class Sector
    {
        [Key]
        public int SectorKey { get; set; }
        [ForeignKey(nameof(Governrate))]
        public int GovernrateKey { get; set; }
        public string SectorName { get; set; }

        public virtual Governrate Governrate { get; set; }
        public virtual ICollection<Zone> Zones { get; set; }
    }
}
