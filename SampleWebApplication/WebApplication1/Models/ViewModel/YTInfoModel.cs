using System.ComponentModel.DataAnnotations;

namespace MyWebApplication.Models.ViewModel
{
    public class YTInfoModel
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^(https?://)?(www\.)?(youtube\.com/(\S+/?\S*|embed/|v/|channels/|user/\S+)|youtu\.be/(\S+/?\S*))$", ErrorMessage = "Invalid Youtube Link")]
        [Display(Name = "YTLink")]
        public string YTLink { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(100, ErrorMessage = "Maximum length is 100 characters.")]
        [Display(Name = "YTTitle")]
        public string YTTitle { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(55, ErrorMessage = "Maximum length is 55 characters.")]
        [Display(Name = "YTTitle")]
        public string Notes { get; set; }
        public int CreatedBy { get; set; }
    }

    public class YTInfosModel
    {
        public List<YTInfoModel> YTInfos { get; set; }
    }
}
