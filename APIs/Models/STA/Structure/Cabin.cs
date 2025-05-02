using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models.STA.Structure
{
    public class Cabin
    {
        [Key]
        public int CabinKey { get; set; }
        [ForeignKey(nameof(Tower))]
        public int TowerKey { get; set; }
        public string CabinName { get; set; }

        public virtual Tower Tower { get; set; }
        public virtual ICollection<Cable> Cables { get; set; }
    }
}
