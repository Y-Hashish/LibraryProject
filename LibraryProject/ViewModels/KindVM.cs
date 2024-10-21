using System.ComponentModel.DataAnnotations;

namespace LibraryProject.ViewModels 
{
    public class KindVM
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}
