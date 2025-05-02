using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models.FTA.Hierarchy
{
    public class NetworkElement
    {
        [Key]
        public int NetworkElementKey { get; set; }
        public string NetworkElementName { get; set; }

        [ForeignKey(nameof(NetworkElementType))]
        public int NetworkElementTypeKey { get; set; }
        public virtual NetworkElementType NetworkElementType { get; set; }

        [ForeignKey(nameof(NetworkElementHierarchyPath))]
        public int NetworkElementHierarchyPathKey { get; set; }
        public virtual NetworkElementHierarchyPath NetworkElementHierarchyPath { get; set; }

        [ForeignKey(nameof(ParentNetworkElement))]
        public int? ParentNetworkElementKey { get; set; }
        public virtual NetworkElement ParentNetworkElement { get; set; }

        public virtual ICollection<NetworkElement> ChildNetworkElements { get; set; }
    }
}
