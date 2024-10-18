using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Models
{
    public class Return
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Borrowing))]
        public int BorrowingId { get; set; }
        [Required]
        public DateTime ActualReturnDate { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        public Borrowing? Borrowing { get; set; }
        public Penality? Penality { get; set; }


    }
}
