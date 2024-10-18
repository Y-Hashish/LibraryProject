using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Models
{
    public class Borrowing
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        [Required]
        public DateTime BorrowingDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public Book? Book{ get; set; }
        public Return? Return{ get; set; }







    }
}
