using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMALS.Models
{
    public class Loan
    {   
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
