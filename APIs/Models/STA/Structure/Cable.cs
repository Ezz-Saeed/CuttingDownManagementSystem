using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models.STA.Structure
{
    public class Cable
    {
        [Key]
        public int CableKey { get; set; }
        [ForeignKey(nameof(Cabin))]
        public int CabinKey { get; set; }
        public string CableName { get; set; }

        public virtual Cabin Cabin { get; set; }
        public virtual ICollection<Block> Blocks { get; set; }
    }
}
