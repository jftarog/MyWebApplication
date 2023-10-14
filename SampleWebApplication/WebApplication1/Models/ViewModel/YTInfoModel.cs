using System.ComponentModel.DataAnnotations;

namespace MyWebApplication.Models.ViewModel
{
    public class YTInfoModel
    {
        [Key]
        public int id { get; set; }
        public string YTLink { get; set; }
        public string YTTitle { get; set; }
        public string Notes { get; set; }
        public int CreatedBy { get; set; }
    }

    public class YTInfosModel
    {
        public List<YTInfoModel> YTInfos { get; set; }
    }
}
