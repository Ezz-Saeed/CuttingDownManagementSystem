using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models.STA.Structure
{
    public class Flat
    {
        [Key]
        public int FlatKey { get; set; }
        [ForeignKey(nameof(Building))]
        public int BuildingKey { get; set; }

        public virtual Building Building { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
