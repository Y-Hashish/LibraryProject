using Microsoft.AspNetCore.Identity;

namespace LibraryProject.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string? address { get; set; }   
    }
}
