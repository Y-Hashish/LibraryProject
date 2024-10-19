using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        
        [ForeignKey(nameof(Kind))]
        public int KindId { get; set; }
        
        [ForeignKey(nameof(BookStatus))]
        public int StatusId { get; set; }

        public Kind? Kind { get; set; }
        public BookStatus? BookStatus { get; set; }
        public ICollection<Borrowing> BorrowingList { get; set; } = new List<Borrowing>();



    }
}
