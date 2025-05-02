using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace APIs.Models.STA.Structure
{
    public class Block
    {
        [Key]
        public int BlockKey { get; set; }
        [ForeignKey(nameof(Cable))]
        public int CableKey { get; set; }
        public string BlockName { get; set; }

        public virtual Cable Cable { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
    }
}
