using System.ComponentModel.DataAnnotations;

namespace LibraryProject.ViewModels
{
    public class RegisterVM
    {
        public string Username { get; set; }

        public string Email { get; set; }
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
