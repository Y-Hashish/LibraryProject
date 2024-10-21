using System.ComponentModel.DataAnnotations;

namespace LibraryProject.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="User Name")]
        public string name { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name="Remember me")]
        public bool rememberMe { get; set; }
    }
}
