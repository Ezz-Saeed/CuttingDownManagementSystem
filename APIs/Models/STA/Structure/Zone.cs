using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models.STA.Structure
{
    public class Zone
    {
        [Key]
        public int ZoneKey { get; set; }
        [ForeignKey(nameof(Sector))]
        public int SectorKey { get; set; }
        public string ZoneName { get; set; }

        public virtual Sector Sector { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
