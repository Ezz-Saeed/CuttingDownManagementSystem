using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models.FTA.Hierarchy
{
    public class NetworkElementType
    {
        [Key]
        //[ForeignKey(nameof(ChildTypes))]
        public int NetworkElementTypeKey { get; set; }
        public string NetworkElementTypeName { get; set; }

        [ForeignKey(nameof(ParentType))]
        public int? ParentNetworkElementTypeKey { get; set; }
        public virtual NetworkElementType ParentType { get; set; }

        [ForeignKey(nameof(NetworkElementHierarchyPath))]
        public int NetworkElementHierarchyPathKey { get; set; }
        public virtual NetworkElementHierarchyPath NetworkElementHierarchyPath { get; set; }

        public virtual ICollection<NetworkElementType> ChildTypes { get; set; }
        public virtual ICollection<NetworkElement> NetworkElements { get; set; }
    }
}
