using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Models
{
    public class Borrowing
    {
        [Key]
        [Display(Name = "Borrow_Id")]
        public int Id { get; set; }

        [ForeignKey(nameof(Book))]
        [Display(Name = "Book")]
        public int BookId { get; set; }


        [ForeignKey(nameof(ApplicationUser))]
        [Display(Name = "UserName")]
        public string ApplicationUserId { get; set; }

        [Display(Name = "Borrow_Date")]
        [Required]
        public DateTime BorrowingDate { get; set; }

        [Display(Name = "Due_Date")]
        [Required]
        public DateTime DueDate { get; set; }

        [Display(Name = "Actual_Return_Date")]
        public DateTime ActualReturnDate { get; set; }

        [Display(Name = "Penality")]
        public double? PenalityAmount { get;  set; }
        

        public Book? Book{ get; set; }

        public ApplicationUser? ApplicationUser { get; set; }
       
    }
}
