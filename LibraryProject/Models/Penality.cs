using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Models
{
    public class Penality
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Amount { get; set; }
        [ForeignKey(nameof(Return))]
        public int ReturnId { get; set; }
        
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        public Return? Return { get; set; }

    }
}
