using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;

namespace APIs.Models.STA.Structure
{
    public class Tower
    {
        [Key]
        public int TowerKey { get; set; }
        [ForeignKey(nameof(Station))]
        public int StationKey { get; set; }
        public string TowerName { get; set; }

        public virtual Station Station { get; set; }
        public virtual ICollection<Cabin> Cabins { get; set; }
    }
}
