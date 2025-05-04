using APIs.Models.FTA.Hierarchy;

namespace APIs.DTOs
{
    public class NetworkElementDto
    {
        public int NetworkElementKey { get; set; }
        public string NetworkElementName { get; set; }
        public string NetworkElementType { get; set; }
        public int? ParentKey { get; set; }
        public ICollection<NetworkElementDto>? Children { get; set; }
    }
}
