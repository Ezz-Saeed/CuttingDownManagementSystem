using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models.STA.Structure
{
    public class Subscription
    {
        [Key]
        public int SubscriptionKey { get; set; }
        [ForeignKey(nameof(Flat))]
        public int FlatKey { get; set; }
        [ForeignKey(nameof(Building))]
        public int BuildingKey { get; set; }
        public int? MeterKey { get; set; }
        public int? PaletKey { get; set; }

        public virtual Flat Flat { get; set; }
        public virtual Building Building { get; set; }
    }
}
