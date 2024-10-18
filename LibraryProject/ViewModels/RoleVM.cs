using System.ComponentModel.DataAnnotations;

namespace LibraryProject.ViewModels
{
    public class RoleVM
    {
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
