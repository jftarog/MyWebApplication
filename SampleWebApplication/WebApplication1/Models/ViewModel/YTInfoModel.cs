using System.ComponentModel.DataAnnotations;

namespace MyWebApplication.Models.ViewModel
{
    public class YTInfoModel
    {
        [Key]
        public int id { get; set; }
        public string YTLink { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Link")]
        public string YTTitle { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Title")]
        public string YTUploader { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Uploader")]
        public int CreatedBy { get; set; }
    }

    public class YTInfosModel
    {
        public List<YTInfoModel> YTInfos { get; set; }
    }
}
