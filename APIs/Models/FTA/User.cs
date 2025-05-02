using System.ComponentModel.DataAnnotations;

namespace APIs.Models.FTA
{
    public class User
    {
        [Key]
        public int UserKey { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
