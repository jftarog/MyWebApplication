using System.ComponentModel.DataAnnotations;

namespace MyWebApplication.Models.DB
{
    public class YTInfo
    {
        [Key]
        public int id { get; set; }
        public string YTLink { get; set; }
        public string YTTitle { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
