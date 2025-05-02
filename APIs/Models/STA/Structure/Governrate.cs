using System.ComponentModel.DataAnnotations;

namespace APIs.Models.STA.Structure
{
    public class Governrate
    {
        [Key]
        public int GovernrateKey { get; set; }
        public string GovernrateName { get; set; }

        public virtual ICollection<Sector> Sectors { get; set; }
    }
}
