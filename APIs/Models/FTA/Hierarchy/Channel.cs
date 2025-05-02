using System.ComponentModel.DataAnnotations;

namespace APIs.Models.FTA.Hierarchy
{
    public class Channel
    {
        [Key]
        public int ChannelKey { get; set; }
        public string ChannelName { get; set; }
    }
}
