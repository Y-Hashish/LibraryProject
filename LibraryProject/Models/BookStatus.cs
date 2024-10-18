using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class BookStatus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Book> BookList { get; set; } = new List<Book>();
    }
}
