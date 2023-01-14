using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StudentAnn.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
