using System.ComponentModel.DataAnnotations;

namespace Maintenance.Web.Models
{
    public class PageContentViewModel
    {
        [Required]
        [Display(Name = "Top Page Content")]
        public string TopContent { get; set; }

        [Required]
        [Display(Name = "Bottom Page Content")]
        public string BottomContent { get; set; }
    }
}
