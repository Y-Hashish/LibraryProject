using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class Kind
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public ICollection<Book> BookList { get; set; } = new List<Book>();

    }
}
