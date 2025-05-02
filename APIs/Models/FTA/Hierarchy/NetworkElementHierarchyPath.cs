using System.ComponentModel.DataAnnotations;

namespace APIs.Models.FTA.Hierarchy
{
    public class NetworkElementHierarchyPath
    {
        [Key]
        public int NetworkElementHierarchyPathKey { get; set; }
        public string NetworkElementHierarchyPathName { get; set; }
        public string Abbreviation { get; set; }

        public virtual ICollection<NetworkElementType> NetworkElementTypes { get; set; }
        public virtual ICollection<NetworkElement> NetworkElements { get; set; }
    }
}
