using System.ComponentModel.DataAnnotations;

namespace LibraryProject.ViewModels
{
    public class RegisterVM
    {
        [Display(Name ="User Name")]
        public string Username { get; set; }
        //[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.^[a-zA-Z]")
        public string Email { get; set; }
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
