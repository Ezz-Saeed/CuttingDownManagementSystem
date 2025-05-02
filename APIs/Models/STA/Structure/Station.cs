using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models.STA.Structure
{
    public class Station
    {
        [Key]
        public int StationKey { get; set; }
        [ForeignKey(nameof(City))]
        public int CityKey { get; set; }
        public string StationName { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Tower> Towers { get; set; }
    }
}
