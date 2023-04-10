using System.ComponentModel.DataAnnotations;

namespace SMALS.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}
