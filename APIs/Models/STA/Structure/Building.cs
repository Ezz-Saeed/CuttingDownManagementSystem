using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models.STA.Structure
{
    public class Building
    {
        [Key]
        public int BuildingKey { get; set; }
        [ForeignKey(nameof(Block))]
        public int BlockKey { get; set; }
        public string BuildingName { get; set; }

        public virtual Block Block { get; set; }
        public virtual ICollection<Flat> Flats { get; set; }
    }
}
