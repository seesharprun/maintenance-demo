using System.ComponentModel.DataAnnotations;
namespace Maintenance.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Password { get; set; }
    }
}
