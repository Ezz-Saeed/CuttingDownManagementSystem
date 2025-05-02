using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models.STA.Structure
{
    public class City
    {
        [Key]
        public int CityKey { get; set; }
        [ForeignKey(nameof(Zone))]
        public int ZoneKey { get; set; }
        public string CityName { get; set; }

        public virtual Zone Zone { get; set; }
        public virtual ICollection<Station> Stations { get; set; }
    }
}
